using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  

public class Alt_karakter : MonoBehaviour
{

    GameObject Target;
    NavMeshAgent _Navmesh;

    // Start is called before the first frame update
    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
        Target = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().VarisNoktasi;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        _Navmesh.SetDestination(Target.transform.position); // Surekli o positionu takip etmesini sagliyoruz. 
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("igneliKutu"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);
            
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektiOlustur(yeniPoz);
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Testere"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);

            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektiOlustur(yeniPoz);
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Pervaneigneler"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);

            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektiOlustur(yeniPoz);
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Balyoz"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);

            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektiOlustur(yeniPoz,true);
           
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Dusman"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);

            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().YokOlmaEfektiOlustur(yeniPoz,false,false);

            gameObject.SetActive(false);
        }
    }
}
