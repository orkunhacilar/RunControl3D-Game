using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Orkun
{
    public class Matematiksel_islemler 
    {


        public void Carpma(int Gelensayi, List<GameObject> Karakterler, Transform Pozisyon, List<GameObject> OlusturmaEfektleri)
        {
            int DonguSayisi = (GameManager.AnlikKarakterSayisi * Gelensayi) - GameManager.AnlikKarakterSayisi;
            //                            10                        3                      10     = 20
            //                            5                        6                      5     = 25
            //                            4                        5                      4     = 16
            int sayi = 0;
            foreach (var item in Karakterler)
            {
                if (sayi < DonguSayisi)
                {

                    if (!item.activeInHierarchy) // aktif degilse o karakter
                    {
                        foreach (var item2 in OlusturmaEfektleri)
                        {
                            if (!item2.activeInHierarchy)
                            {
                               

                                item2.SetActive(true);
                                item2.transform.position = Pozisyon.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                item2.GetComponent<AudioSource>().Play(); // karakter olustugu zaman muzik calmak icin yazdigimiz kod
                                break;
                            }
                        }

                        item.transform.position = Pozisyon.position;
                        item.SetActive(true);
                        sayi++;

                    }

                }
                else
                {
                    sayi = 0;
                    break;

                }


            }
            GameManager.AnlikKarakterSayisi *= Gelensayi;
        }

        public void Toplama(int Gelensayi, List<GameObject> Karakterler, Transform Pozisyon, List<GameObject> OlusturmaEfektleri)
        {

            int sayi2 = 0;
            foreach (var item in Karakterler)
            {
                if (sayi2 < Gelensayi)
                {

                    if (!item.activeInHierarchy) // aktif degilse o karakter
                    {

                        foreach (var item2 in OlusturmaEfektleri)
                        {
                            if (!item2.activeInHierarchy)
                            {


                                item2.SetActive(true);
                                item2.transform.position = Pozisyon.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                item2.GetComponent<AudioSource>().Play(); // karakter olustugu zaman muzik calmak icin yazdigimiz kod
                                break;
                            }
                        }

                        item.transform.position = Pozisyon.position;
                        item.SetActive(true);
                        sayi2++;

                    }

                }
                else
                {
                    sayi2 = 0;
                    break;

                }


            }
           GameManager.AnlikKarakterSayisi += Gelensayi;

        }

        public void Cikartma(int Gelensayi, List<GameObject> Karakterler, List<GameObject> YokOlmaEfektleri)
        {
            if (GameManager.AnlikKarakterSayisi < Gelensayi)
            {
                foreach (var item in Karakterler)
                {

                    foreach (var item2 in YokOlmaEfektleri)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                            item2.SetActive(true);
                            item2.transform.position = yeniPoz;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play(); //  yok olma sesi
                            break;
                        }
                    }

                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
               GameManager.AnlikKarakterSayisi = 1;
            }
            else
            {

                int sayi3 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi3 != Gelensayi)
                    {

                        if (item.activeInHierarchy) // aktif ise
                        {


                            foreach (var item2 in YokOlmaEfektleri)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                                    item2.SetActive(true);
                                    item2.transform.position = yeniPoz;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().Play(); //  yok olma sesi
                                    break;
                                }
                            }

                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi3++;

                        }

                    }
                    else
                    {
                        sayi3 = 0;
                        break;

                    }


                }
               GameManager.AnlikKarakterSayisi -= Gelensayi;
            }
        }

        public void Bolme(int Gelensayi, List<GameObject> Karakterler, List<GameObject> YokOlmaEfektleri)
        {

            if (GameManager.AnlikKarakterSayisi <= Gelensayi)
            {
                foreach (var item in Karakterler)
                {

                    foreach (var item2 in YokOlmaEfektleri)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                            item2.SetActive(true);
                            item2.transform.position = yeniPoz;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play(); //  yok olma sesi
                            break;
                        }
                    }

                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
               GameManager.AnlikKarakterSayisi = 1;
            }
            else
            {
                int bolen =  GameManager.AnlikKarakterSayisi / Gelensayi;

                int sayi3 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi3 != bolen)
                    {

                        if (item.activeInHierarchy) // aktif ise
                        {
                            foreach (var item2 in YokOlmaEfektleri)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                                    item2.SetActive(true);
                                    item2.transform.position = yeniPoz;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().Play(); //  yok olma sesi
                                    break;
                                }
                            }

                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi3++;

                        }

                    }
                    else
                    {
                        sayi3 = 0;
                        break;

                    }


                }

                if (GameManager.AnlikKarakterSayisi % Gelensayi == 0)
                {
                    GameManager.AnlikKarakterSayisi /= Gelensayi;
                }
                else if (GameManager.AnlikKarakterSayisi % Gelensayi == 1)
                {
                    GameManager.AnlikKarakterSayisi /= Gelensayi;
                    GameManager.AnlikKarakterSayisi++;
                }
                else if (GameManager.AnlikKarakterSayisi % Gelensayi == 2)
                {
                    GameManager.AnlikKarakterSayisi /= Gelensayi;
                    GameManager.AnlikKarakterSayisi+=2;
                }
                
            }

        }
    }


    public class BellekYonetim
    {

        public void VeriKaydet_string(string Key, string value)
        {
            PlayerPrefs.SetString(Key, value);
            PlayerPrefs.Save();
        }

        public void VeriKaydet_int(string Key, int value)
        {
            PlayerPrefs.SetInt(Key, value);
            PlayerPrefs.Save();
        }

        public void VeriKaydet_float(string Key, float value)
        {
            PlayerPrefs.SetFloat(Key, value);
            PlayerPrefs.Save();
        }


        public string VeriOku_s(string Key)
        {
            return PlayerPrefs.GetString(Key);
        }

        public int VeriOku_i(string Key)
        {
            return PlayerPrefs.GetInt(Key);
        }

        public float VeriOku_f(string Key)
        {
            return PlayerPrefs.GetFloat(Key);
        }


        public void KontrolEtmeveTanimlama()
        {
            if (!PlayerPrefs.HasKey("SonLevel")) // Eger kaydedili bir lv yoksa bu oyuna yeni girdigini gosterir ve set int ile 5 kaydediyorum neden 5 build settings ilk lv 5. sira.
            {
                PlayerPrefs.SetInt("SonLevel", 5);
                PlayerPrefs.SetInt("Puan", 100);
                PlayerPrefs.SetInt("AktifSapka", -1);
                PlayerPrefs.SetInt("AktifSopa", -1);
                PlayerPrefs.SetInt("AktifTema", -1);

                PlayerPrefs.SetFloat("MenuSes", 1);
                PlayerPrefs.SetFloat("MenuFx", 1);
                PlayerPrefs.SetFloat("OyunSes", 1);

            }
        }






    }


   


    [Serializable]  // bu komut bu clasi liste araciligi ile kullanma + serilestirmemize yariyor.
    public class ItemBilgileri
    {
        public int GrupIndex;
        public int Item_Index;
        public string Item_Ad;
        public int Puan;
        public bool SatinAlmaDurumu;
    }

    public class VeriYonetimi
    {
        public void Save(List<ItemBilgileri> _ItemBilgileri)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.persistentDataPath + "/ItemVerileri.gd"); //dosya olusturduk
            bf.Serialize(file, _ItemBilgileri); // verileri yaziyoruz
            file.Close(); // isimiz bittiginde dosyayi kapatiyoruz.
        }

        



        List<ItemBilgileri> _ItemicListe;

        public void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/ItemVerileri.gd")) //her zaman bakiyorum dosyam var mi yok mu ? silinmis olabilir cunku
            {

                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/ItemVerileri.gd", FileMode.Open); //dosya olusturduk
                _ItemicListe = (List<ItemBilgileri>)bf.Deserialize(file); //File okuyup int cast ettik.
                file.Close(); // isimiz bittiginde dosyayi kapatiyoruz.
            }
        }

        public List<ItemBilgileri> ListeyiAktar()
        {
            return _ItemicListe;
        }


        public void ilkKurulumDosyaOlusturmaa(List<ItemBilgileri> _ItemBilgileri)
        {
            if (!File.Exists(Application.persistentDataPath + "/ItemVerileri.gd")) // eger dosya yoksa ilk kez olustur
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + "/ItemVerileri.gd"); //dosya olusturduk
                bf.Serialize(file, _ItemBilgileri); // verileri yaziyoruz
                file.Close(); // isimiz bittiginde dosyayi kapatiyoruz.
            }

        }
    }
}
