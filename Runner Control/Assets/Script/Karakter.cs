using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    public GameManager _GameManager;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * .5f * Time.deltaTime); // Karakter dum duz ileri gitsin 
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0)) // Mouse sol click basilirsa = Mouse0
        {

            // Mouse X in konumuna bak ve 0 dan kucuk ya da buyukse Lerp Metodu ile saga sola kay demek icin yazdigimiz kod !
            if(Input.GetAxis("Mouse X") < 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .3f);
            }
            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
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
    }
}
