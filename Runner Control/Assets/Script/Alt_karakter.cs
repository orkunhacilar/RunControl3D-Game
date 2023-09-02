using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  

public class Alt_karakter : MonoBehaviour
{

    
    NavMeshAgent _Navmesh;
    public GameManager _Gamemanager;
    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
      
     
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        _Navmesh.SetDestination(Target.transform.position); // Surekli o positionu takip etmesini sagliyoruz. 
    }

    Vector3 PozisyonVer() {
       return new Vector3(transform.position.x, .23f, transform.position.z);
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("igneliKutu"))
        {
            _Gamemanager.YokOlmaEfektiOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }

       else if (other.CompareTag("Testere"))
        {
            _Gamemanager.YokOlmaEfektiOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }

        else if (other.CompareTag("Pervaneigneler"))
        {
            _Gamemanager.YokOlmaEfektiOlustur(PozisyonVer());
            gameObject.SetActive(false);
        }

        else if (other.CompareTag("Balyoz"))
        {
            _Gamemanager.YokOlmaEfektiOlustur(PozisyonVer(), true);
            gameObject.SetActive(false);
        }

        else if (other.CompareTag("Dusman"))
        {
         _Gamemanager.YokOlmaEfektiOlustur(PozisyonVer(), false,false);
         gameObject.SetActive(false);
        }
        else if (other.CompareTag("BosKarakter"))
        {
            _Gamemanager.Karakterler.Add(other.gameObject); // Bos karakter carparsa bizim alt karakter listesine ARRAYINE ekle dedik
           
        }
    }
}
