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

    // Start is called before the first frame update
    void Start()
    {

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

    public void SahneYukle(int Index)
    {
        ButonSes.Play();
      SceneManager.LoadScene(Index);
      
       
    }



    public void GeriDon()
    {
        ButonSes.Play();
        SceneManager.LoadScene(0);
    }
}
