using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Orkun;


public class Ozellestirme : MonoBehaviour
{

    public Text PuanText;
    
    public GameObject[] islemPanelleri;
    public GameObject islemCanvasi;
    public GameObject[] GenelObjeler;
    int AktifislemPaneliIndex;
    [Header("-------------SAPKALAR")]
    public GameObject[] Sapkalar;
    public Button[] SapkaButonlari;
    public Text SapkaText;
    [Header("-------------SOPALAR")]
    public GameObject[] Sopalar;
    public Button[] SopaButonlari;
    public Text SopaText;
    [Header("-------------MATERIAL")]
    public Material[] Materyaller;     // RENKLER oldugu icin Material arrayi aciyorum
    public Button[] MateryalButonlari;
    public Text MaterialText;

    int SapkaIndex = -1;
    int SopaIndex = -1;
    int MaterialIndex = -1;

    BellekYonetim _BellekYonetim = new BellekYonetim();
    VeriYonetimi _VeriYonetim = new VeriYonetimi();
    [Header("-------------GENEL VERILER")]
    public List<ItemBilgileri> _ItemBilgileri = new List<ItemBilgileri>();


 
    void Start()
    {
        Debug.Log(Application.persistentDataPath + "/ItemVerileri.gd");

        _BellekYonetim.VeriKaydet_int("AktifSapka", -1);
        _BellekYonetim.VeriKaydet_int("AktifSopa", -1);


        if (_BellekYonetim.VeriOku_i("AktifSapka") == -1){

            foreach(var item in Sapkalar)
            {
                item.SetActive(false);
            }
            SapkaIndex = -1;
            SapkaText.text = "No Hat";
        }
        else
        {
            SapkaIndex = _BellekYonetim.VeriOku_i("AktifSapka");
            Sapkalar[SapkaIndex].SetActive(true);
        }



        if (_BellekYonetim.VeriOku_i("AktifSopa") == -1)
        {

            foreach (var item in Sopalar)
            {
                item.SetActive(false);
            }
            SopaIndex = -1;
            SopaText.text = "No Bat";
        }
        else
        {
            SopaIndex = _BellekYonetim.VeriOku_i("AktifSopa");
            Sopalar[SopaIndex].SetActive(true);
        }



        // _VeriYonetim.Save(_ItemBilgileri);

        _VeriYonetim.Load();
        _ItemBilgileri = _VeriYonetim.ListeyiAktar();

        //Load();
        //Save();
    }


   

    public void Sapka_Yonbutonlari(string islem)
    {
        if(islem == "ileri")
        {
            if(SapkaIndex == -1)
            {
                SapkaIndex = 0;
                Sapkalar[SapkaIndex].SetActive(true);
                SapkaText.text = _ItemBilgileri[SapkaIndex].Item_Ad;
            }
            else
            {
                Sapkalar[SapkaIndex].SetActive(false);
                SapkaIndex++;
                Sapkalar[SapkaIndex].SetActive(true);
                SapkaText.text = _ItemBilgileri[SapkaIndex].Item_Ad;
            }
            //----------------------------------------

            if (SapkaIndex == Sapkalar.Length - 1)     // Son sapkaya geldigini anlamak icin yazdik
                SapkaButonlari[1].interactable = false;  // daha ileri gitmesin diye butonu kapatiyoruz.
            else
                SapkaButonlari[1].interactable = true;

            if (SapkaIndex != -1)
            {
                SapkaButonlari[0].interactable = true;
            }
        }
        else
        {
            if (SapkaIndex != -1)
            {
                Sapkalar[SapkaIndex].SetActive(false);
                SapkaIndex--;

                if (SapkaIndex != -1)
                {
                    Sapkalar[SapkaIndex].SetActive(true);
                    SapkaButonlari[0].interactable = true;
                    SapkaText.text = _ItemBilgileri[SapkaIndex].Item_Ad;
                }
                else
                {
                    SapkaButonlari[0].interactable = false;
                    SapkaText.text = "No Hat";
                }
            }
            else
            {
                SapkaButonlari[0].interactable = false;
                SapkaText.text = "No Hat";
            }
            //----------------------------------------
            if (SapkaIndex != Sapkalar.Length - 1)     
                SapkaButonlari[1].interactable = true;

        }
    }

    public void Sopa_Yonbutonlari(string islem)
    {
        if (islem == "ileri")
        {
            if (SopaIndex == -1)
            {
                SopaIndex = 0;
                Sopalar[SopaIndex].SetActive(true);
                SopaText.text = _ItemBilgileri[SopaIndex + 3].Item_Ad;
            }
            else
            {
                Sopalar[SopaIndex].SetActive(false);
                SopaIndex++;
                Sopalar[SopaIndex].SetActive(true);
                SopaText.text = _ItemBilgileri[SopaIndex + 3].Item_Ad;
            }
            //----------------------------------------

            if (SopaIndex == Sopalar.Length - 1)     // Son sapkaya geldigini anlamak icin yazdik
                SopaButonlari[1].interactable = false;  // daha ileri gitmesin diye butonu kapatiyoruz.
            else
                SopaButonlari[1].interactable = true;

            if (SopaIndex != -1)
            {
                SopaButonlari[0].interactable = true;
            }
        }
        else
        {
            if (SopaIndex != -1)
            {
                Sopalar[SopaIndex].SetActive(false);
                SopaIndex--;

                if (SopaIndex != -1)
                {
                    Sopalar[SopaIndex].SetActive(true);
                    SopaButonlari[0].interactable = true;
                    SopaText.text = _ItemBilgileri[SopaIndex + 3].Item_Ad;
                }
                else
                {
                    SopaButonlari[0].interactable = false;
                    SopaText.text = "No Bat";
                }
            }
            else
            {
                SopaButonlari[0].interactable = false;
                SopaText.text = "No Bat";
            }
            //----------------------------------------
            if (SopaIndex != Sopalar.Length - 1)
                SopaButonlari[1].interactable = true;

        }
    }


    public void islemPaneliCikart(int Index)
    {
        GenelObjeler[2].SetActive(true);
        AktifislemPaneliIndex = Index;
        islemPanelleri[Index].SetActive(true);
        GenelObjeler[3].SetActive(true);
        islemCanvasi.SetActive(false);
       
        
    }

    public void GeriDon()
    {
        GenelObjeler[2].SetActive(false);
        islemCanvasi.SetActive(true);
        GenelObjeler[3].SetActive(false);
        islemPanelleri[AktifislemPaneliIndex].SetActive(false);
    }

}
