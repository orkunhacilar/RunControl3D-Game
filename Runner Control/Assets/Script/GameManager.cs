using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Orkun;

public class GameManager : MonoBehaviour
{

  
    
    public GameObject VarisNoktasi;
    public static int AnlikKarakterSayisi = 1;

    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;


    void Start()
    {
        
    }

    void Update()
    {

      

    }

    public void AdamYonetimi(string islemturu, int GelenSayi, Transform Pozisyon)
    {
        switch (islemturu)
        {
            case "Carpma":

                Matematiksel_islemler.Carpma(GelenSayi, Karakterler, Pozisyon);
               
                break;

            case "Toplama":

                Matematiksel_islemler.Toplama(GelenSayi, Karakterler, Pozisyon);

                break;


            case "Cikartma":

                Matematiksel_islemler.Cikartma(GelenSayi, Karakterler);
               
               
                break;




            case "Bolme":
                Matematiksel_islemler.Bolme(GelenSayi, Karakterler);


                break;
        }
    }


    public void YokOlmaEfektiOlustur(Vector3 Pozisyon)
    {
        foreach(var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = Pozisyon;
                item.GetComponent<ParticleSystem>().Play();
                AnlikKarakterSayisi--;
                break;
            }
        }
    }
}
