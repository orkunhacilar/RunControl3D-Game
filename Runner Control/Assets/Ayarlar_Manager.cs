using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Orkun;

public class Ayarlar_Manager : MonoBehaviour
{
    public AudioSource ButonSes;
    public Slider MenuSes;
    public Slider MenuFx;
    public Slider OyunSes;
    BellekYonetim _Bellekyonetim = new BellekYonetim();
    VeriYonetimi _VeriYonetim = new VeriYonetimi();
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>(); // Kutuphane classinda yazili olan bir class listesi tutan classi bizde list seklinde aldik.
    List<DilVerileriAnaObje> _DilOkunanVeriler = new List<DilVerileriAnaObje>();
    public Text[] TextObjeleri;


    [Header ("------------Dil Tercihi Objeleri")]
    public Text DilText;
    public Button[] DilButonlari;
    int AktifDilIndex=0;

    void Start()
    {
        ButonSes.volume = _Bellekyonetim.VeriOku_f("MenuFx");

        MenuSes.value = _Bellekyonetim.VeriOku_f("MenuSes");   //kayitli olan sesi cagir
        MenuFx.value = _Bellekyonetim.VeriOku_f("MenuFx");
        OyunSes.value = _Bellekyonetim.VeriOku_f("OyunSes");
       


        _VeriYonetim.Dil_Load();
        _DilOkunanVeriler = _VeriYonetim.DilVerileriListeyiAktar();
        _DilVerileriAnaObje.Add(_DilOkunanVeriler[4]);
        DilTercihiYonetimi();
        DilDurumunuKontrolEt();

    }

    void DilTercihiYonetimi()
    {
        if (_Bellekyonetim.VeriOku_s("Dil") == "TR")
        {
            for (int i = 0; i < TextObjeleri.Length; i++) // GIT BENIM TEXT OBJELERIMI GEZ
            {
                TextObjeleri[i].text = _DilVerileriAnaObje[0]._DilVerileri_TR[i].Metin; // DIL VERILERI ANA OBJE[0] CUNKU ANA EKRANDAYIZ ONDAN SONRASINI ZATEN OKURSUN KOLAY
            }
        }
        else
        {
            for (int i = 0; i < TextObjeleri.Length; i++) // GIT BENIM TEXT OBJELERIMI GEZ
            {
                TextObjeleri[i].text = _DilVerileriAnaObje[0]._DilVerileri_EN[i].Metin; // DIL VERILERI ANA OBJE[0] CUNKU ANA EKRANDAYIZ ONDAN SONRASINI ZATEN OKURSUN KOLAY
            }
        }
    }



    public void SesAyarla(string HangiAyar)
    {

        switch (HangiAyar)
        {
            case "menuses":
               
                _Bellekyonetim.VeriKaydet_float("MenuSes", MenuSes.value); // Menude ses ne ise onu kaydet
                break;

            case "menufx":
                
                _Bellekyonetim.VeriKaydet_float("MenuFx", MenuFx.value); // Menude ses ne ise onu kaydet
                break;

            case "oyunses":
                
                _Bellekyonetim.VeriKaydet_float("OyunSes", OyunSes.value); // Menude ses ne ise onu kaydet
                break;
        }
    }

    public void GeriDon()
    {
        ButonSes.Play();
        SceneManager.LoadScene(0);
    }

    void DilDurumunuKontrolEt()
    {
        if (_Bellekyonetim.VeriOku_s("Dil") == "TR")
        {
            AktifDilIndex = 0;
            DilText.text = "TURKISH";
            DilButonlari[0].interactable = false; //Dil butonlarinin 0 cisini false yap dedik.
        }
        else
        {
            AktifDilIndex = 1;
            DilText.text = "ENGLISH";
            DilButonlari[1].interactable = false; //Dil butonlarinin 0 cisini false yap dedik.
        }
    }

    public void DilDegistir(string Yon)
    {
        if (Yon == "ileri")
        {
            AktifDilIndex = 1;
            DilText.text = "ENGLISH";
            DilButonlari[1].interactable = false; //Dil butonlarinin 1 cisini false yap dedik.
            DilButonlari[0].interactable = true;
            _Bellekyonetim.VeriKaydet_string("Dil", "EN");
            DilTercihiYonetimi();

        }
        else
        {
            AktifDilIndex = 0;
            DilText.text = "TURKISH";
            DilButonlari[0].interactable = false; //Dil butonlarinin 0 cisini false yap dedik.
            DilButonlari[1].interactable = true;
            _Bellekyonetim.VeriKaydet_string("Dil", "TR");
            DilTercihiYonetimi();
        }

        ButonSes.Play();
    }
}
