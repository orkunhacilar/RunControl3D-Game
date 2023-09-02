using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // SLIDER KULLANMAK ICIN EKLEDIK

public class Karakter : MonoBehaviour
{
    public GameManager _GameManager;
    public Kamera _Kamera;
    public bool SonaGeldikmi;
    public GameObject Gidecegiyer;
    public Slider _Slider;
    public GameObject GecisNoktasi;

    private void FixedUpdate()
    {
        if(!SonaGeldikmi) // sona gelmediysek dum duz git
        transform.Translate(Vector3.forward * .5f * Time.deltaTime); // Karakter dum duz ileri gitsin 
    }

    private void Start()
    {
        float Fark = Vector3.Distance(transform.position, GecisNoktasi.transform.position); // Bana karakterim ile bitis noktasi arasindaki mesafeyi ver diyoruz. Distance float donduruyo .
        _Slider.maxValue = Fark;
    }


    // Update is called once per frame
    void Update()
    {
        

        

        if (SonaGeldikmi)  // sona geldiyse karakteri oraya kaydir gibi olan komut
        {
            transform.position = Vector3.Lerp(transform.position, Gidecegiyer.transform.position, .015f);
            if (_Slider.value != 0)
                _Slider.value -= .005f;
        }
        else // sona gelmediysek harakter ettirme komutlari aktif
        {
            float Fark = Vector3.Distance(transform.position, GecisNoktasi.transform.position); // Bana karakterim ile bitis noktasi arasindaki mesafeyi ver diyoruz. Distance float donduruyo .
            _Slider.value = Fark; // aldigin farki slider objeme at

            if (Input.GetKey(KeyCode.Mouse0)) // Mouse sol click basilirsa = Mouse0
            {

                // Mouse X in konumuna bak ve 0 dan kucuk ya da buyukse Lerp Metodu ile saga sola kay demek icin yazdigimiz kod !
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .3f);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
                }

            }
        }

       
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Carpma") || other.CompareTag("Toplama") || other.CompareTag("Cikartma") || other.CompareTag("Bolme"))
        {
            int sayi = int.Parse(other.name);
            _GameManager.AdamYonetimi(other.tag, sayi, other.transform);
            
        }
        else if (other.CompareTag("Sontetikleyici"))
        {
            _Kamera.SonaGeldikmi = true;
            _GameManager.DusmanlariTetikle();
            SonaGeldikmi = true;
        }
        else if (other.CompareTag("BosKarakter"))
        {
            _GameManager.Karakterler.Add(other.gameObject); // Bos karakter carparsa bizim alt karakter listesine ARRAYINE ekle dedik
           
            
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Direk") || collision.gameObject.CompareTag("igneliKutu") || collision.gameObject.CompareTag("Pervaneigneler") )
        {
            if(transform.position.x > 0)
            transform.position = new Vector3(transform.position.x - .3f, transform.position.y, transform.position.z);
            else
            transform.position = new Vector3(transform.position.x + .3f, transform.position.y, transform.position.z);
        }
    }
}
