using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Sahnelerle islem yapiyosak import ediyoruz
using Orkun;
using System.Security.Cryptography;
using UnityEngine.UI;

public class AnaMenu_Manager : MonoBehaviour
{
    BellekYonetim _BellekYonetim = new BellekYonetim();
    VeriYonetimi _VeriYonetim = new VeriYonetimi();
    public GameObject CikisPaneli;
    public List<ItemBilgileri> _Varsayilan_ItemBilgileri = new List<ItemBilgileri>();
    public List<DilVerileriAnaObje> _Varsayilan_DilVerileri = new List<DilVerileriAnaObje>();
    public AudioSource ButonSes;

    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>(); // Kutuphane classinda yazili olan bir class listesi tutan classi bizde list seklinde aldik.
    List<DilVerileriAnaObje> _DilOkunanVeriler = new List<DilVerileriAnaObje>();
    public Text[] TextObjeleri;

    // Start is called before the first frame update
    void Start()
    {
        _BellekYonetim.KontrolEtmeveTanimlama();
        _VeriYonetim.ilkKurulumDosyaOlusturma(_Varsayilan_ItemBilgileri,_Varsayilan_DilVerileri); // ilk dosyayi olusuturp icine veri atiyoruz.
        ButonSes.volume = _BellekYonetim.VeriOku_f("MenuFx");


        // _Bellekyonetim.VeriOku_f("Dil");

        // Debug.Log(_DilVerileriAnaObje[0]._DilVerileri_TR[3].Metin); // GIT LIST ICINDE LISTE ERIS ORDAKI DEGERI VER BAKALIM

      //   _BellekYonetim.VeriKaydet_string("Dil", "TR"); // TR MI ISTIYON EN MI SECIYON ?

        _VeriYonetim.Dil_Load();
        _DilOkunanVeriler = _VeriYonetim.DilVerileriListeyiAktar();
        _DilVerileriAnaObje.Add(_DilOkunanVeriler[0]);
        DilTercihiYonetimi();

    }

    void DilTercihiYonetimi()
    {
        if (_BellekYonetim.VeriOku_s("Dil") == "TR")
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

    public void SahneYukle(int Index)
    {
        ButonSes.Play();
        SceneManager.LoadScene(Index);
    }

    public void Oyna()
    {
        ButonSes.Play();
        SceneManager.LoadScene(_BellekYonetim.VeriOku_i("SonLevel"));
    }

    

    public void CikisButonIslem(string durum)
    {
        ButonSes.Play();
        if (durum == "Evet")
            Application.Quit();  // Bir uygulamayi kapatma metodu
        else if (durum == "cikis")
            CikisPaneli.SetActive(true);
        else
            CikisPaneli.SetActive(false);
    }
}
