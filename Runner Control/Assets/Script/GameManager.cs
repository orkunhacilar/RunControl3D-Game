using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Orkun;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{

  
    
   
    public static int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;
    public List<GameObject> AdamLekesiEfekleri;

    [Header ("LEVEL VERILERI")]
    public List<GameObject> Dusmanlar;
    public int KacDusmanOlsun;
    public GameObject _Anakarakter;
    public bool OyunBittimi;
    bool SonaGeldikmi;

    Matematiksel_islemler _Matematiksel_islemler = new Matematiksel_islemler();
    BellekYonetim _BellekYonetim = new BellekYonetim();



    void Start()
    {
        DusmanlariOlustur();

      

        Debug.Log(_BellekYonetim.VeriOku_i("Puan"));
       
    }

    public void DusmanlariOlustur()
    {
        for (int i = 0; i< KacDusmanOlsun; i++) {

            Dusmanlar[i].SetActive(true);
        }


    }

    public void DusmanlariTetikle()
    {
        foreach (var item in Dusmanlar)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Dusman>().AnimasyonTetikle();
            }
        }
        SonaGeldikmi = true;
        SavasDurumu();
    }


    void Update()
    {

      

    }

    void SavasDurumu()
    {

        if (SonaGeldikmi)
        {
            if (AnlikKarakterSayisi == 1 || KacDusmanOlsun == 0)
            {
                OyunBittimi = true;
                foreach (var item in Dusmanlar)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldir", false);
                    }
                }

                foreach (var item in Karakterler)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldir", false);
                    }
                }

                _Anakarakter.GetComponent<Animator>().SetBool("Saldir", false);

                if (AnlikKarakterSayisi < KacDusmanOlsun || AnlikKarakterSayisi == KacDusmanOlsun)
                {
                    Debug.Log("Kaybettin");
                }
                else
                {
                    if(AnlikKarakterSayisi>5)
                    _BellekYonetim.VeriKaydet_int("Puan", _BellekYonetim.VeriOku_i("Puan") + 600); // puan ekleme
                    else
                        _BellekYonetim.VeriKaydet_int("Puan", _BellekYonetim.VeriOku_i("Puan") + 200); // puan ekleme
                    Debug.Log("Kazandin");
                }
            }
        }

    }

    public void AdamYonetimi(string islemturu, int GelenSayi, Transform Pozisyon)
    {
        switch (islemturu)
        {
            case "Carpma":

                _Matematiksel_islemler.Carpma(GelenSayi, Karakterler, Pozisyon,OlusmaEfektleri);
               
                break;

            case "Toplama":

                _Matematiksel_islemler.Toplama(GelenSayi, Karakterler, Pozisyon,OlusmaEfektleri);

                break;


            case "Cikartma":

                _Matematiksel_islemler.Cikartma(GelenSayi, Karakterler, YokOlmaEfektleri);
               
               
                break;




            case "Bolme":
                _Matematiksel_islemler.Bolme(GelenSayi, Karakterler, YokOlmaEfektleri);


                break;
        }
    }


    public void YokOlmaEfektiOlustur(Vector3 Pozisyon, bool Balyoz=false,bool Durum=false)
    {
        foreach(var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = Pozisyon;
                item.GetComponent<ParticleSystem>().Play();
                item.GetComponent<AudioSource>().Play(); // karakter yok oldugu zaman muzik calmak icin yazdigimiz kod
                if (!Durum)
                    AnlikKarakterSayisi--;
                else
                    KacDusmanOlsun--;
                break;
                
            }
        }

        

        if (Balyoz)
        {
            Vector3 yeniPoz = new Vector3(Pozisyon.x, .005f, Pozisyon.z);
            foreach (var item in AdamLekesiEfekleri)
            {
                if (!item.activeInHierarchy)
                {
                    item.SetActive(true);
                    item.transform.position = yeniPoz;
                    break;
                }
            }

        }

        if(!OyunBittimi)
            SavasDurumu();
    }

    


    
}
