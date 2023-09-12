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

    void Start()
    {
        MenuSes.value = _Bellekyonetim.VeriOku_f("MenuSes");   //kayitli olan sesi cagir
        MenuFx.value = _Bellekyonetim.VeriOku_f("MenuFx");
        OyunSes.value = _Bellekyonetim.VeriOku_f("OyunSes");
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void DilDegistir()
    {
        ButonSes.Play();
    }
}
