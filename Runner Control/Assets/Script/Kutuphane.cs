using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Orkun
{
    public class Matematiksel_islemler : MonoBehaviour
    {


        public static void Carpma(int Gelensayi, List<GameObject> Karakterler, Transform Pozisyon, List<GameObject> OlusturmaEfektleri)
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

        public static void Toplama(int Gelensayi, List<GameObject> Karakterler, Transform Pozisyon, List<GameObject> OlusturmaEfektleri)
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

        public static void Cikartma(int Gelensayi, List<GameObject> Karakterler, List<GameObject> YokOlmaEfektleri)
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

        public static void Bolme(int Gelensayi, List<GameObject> Karakterler, List<GameObject> YokOlmaEfektleri)
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

    


}
