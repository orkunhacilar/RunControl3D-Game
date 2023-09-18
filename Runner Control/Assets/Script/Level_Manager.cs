using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Orkun;
using UnityEngine.EventSystems;   // TEK TEK ISIMDEN YAKALAMAK ISTERSEN



public class Level_Manager : MonoBehaviour
{

    public Button[] Butonlar;
    public int Level;
    public Sprite KilitButon;

    BellekYonetim _BellekYonetim = new BellekYonetim();
    public AudioSource ButonSes;

    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>(); // Kutuphane classinda yazili olan bir class listesi tutan classi bizde list seklinde aldik.
    List<DilVerileriAnaObje> _DilOkunanVeriler = new List<DilVerileriAnaObje>();
    public Text[] TextObjeleri;
    VeriYonetimi _VeriYonetim = new VeriYonetimi();

    public GameObject YuklemeEkrani;
    public Slider YuklemeSlider;

    // Start is called before the first frame update
    void Start()
    {
     

        _VeriYonetim.Dil_Load();
        _DilOkunanVeriler = _VeriYonetim.DilVerileriListeyiAktar();
        _DilVerileriAnaObje.Add(_DilOkunanVeriler[2]);
        DilTercihiYonetimi();

        ButonSes.volume = _BellekYonetim.VeriOku_f("MenuFx");

        int mevcutLevel = _BellekYonetim.VeriOku_i("SonLevel") - 4;  //5  ci lv 1 oldugu icin 4 cikararak kacinci lvde oldugumuzu anliyorum
                                                                     // 5

        int Index = 1;
        for(int i = 0; i < Butonlar.Length; i++)
        {
                // 1       4              ne demek demekki o lv ye kadar olanlari acmisim demek
            if (i + 1 <= mevcutLevel)
            {
                Butonlar[i].GetComponentInChildren<Text>().text = Index.ToString();   // git diyorum acitigim lvlere ustlerine rakamlari yaz.
                // int Index = i + 1;

                int SahneIndex = Index + 4;
                Butonlar[i].onClick.AddListener(delegate { SahneYukle(SahneIndex); });
            }
            else
            {
                Butonlar[i].GetComponent<Image>().sprite = KilitButon; // acmadigim bolumler icinde git o butonlara kilit image i koy diyorum kisaca
                // Butonlar[i].interactable = false;
                Butonlar[i].enabled = false;
            }
            Index++;
        }


       
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
     
        StartCoroutine(LoadAsync(Index));


    }


    IEnumerator LoadAsync(int SceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex); // Bu Komutta diyoruz ki bu sahnemi yukle ama yukerken %30 yuklendi %40 yuklendi gibi olan degeri takip et ve o degeri Op ye aktar.

        YuklemeEkrani.SetActive(true);

        while (!operation.isDone) // Sahne yuklenmedigi surece diyoruz devam et
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); // 0 a ya da 1 tamamlama icin yuvarlama islemi


            YuklemeSlider.value = progress;
            yield return null;
        }

    }



    public void GeriDon()
    {
        ButonSes.Play();
        SceneManager.LoadScene(0);
    }
}
