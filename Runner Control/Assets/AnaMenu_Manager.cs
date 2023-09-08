using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Sahnelerle islem yapiyosak import ediyoruz
using Orkun;

public class AnaMenu_Manager : MonoBehaviour
{
    BellekYonetim _BellekYonetim = new BellekYonetim();
    VeriYonetimi _VeriYonetim = new VeriYonetimi();
    public GameObject CikisPaneli;
    public List<ItemBilgileri> _ItemBilgileri = new List<ItemBilgileri>();

    // Start is called before the first frame update
    void Start()
    {
        _BellekYonetim.KontrolEtmeveTanimlama();
      //  _VeriYonetim.ilkKurulumDosyaOlusturmaa(_ItemBilgileri // diger  tum itemler bitince aktiflestir.
    }

    public void SahneYukle(int Index)
    {
        SceneManager.LoadScene(Index);
    }

    public void Oyna()
    {
        SceneManager.LoadScene(_BellekYonetim.VeriOku_i("SonLevel"));
    }

    

    public void CikisButonIslem(string durum)
    {
        if (durum == "Evet")
            Application.Quit();  // Bir uygulamayi kapatma metodu
        else if (durum == "cikis")
            CikisPaneli.SetActive(true);
        else
            CikisPaneli.SetActive(false);
    }
}
