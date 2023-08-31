using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dusman : MonoBehaviour
{
    public GameObject Saldiri_Hedefi;
    public NavMeshAgent _NavMesh;
    bool Saldiri_Basladimi;
    public GameManager _Gamemanager;
    public Animator _Animator;


    

    public void AnimasyonTetikle()
    {
        _Animator.SetBool("Saldir", true);
        Saldiri_Basladimi = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (Saldiri_Basladimi)
        {
            _NavMesh.SetDestination(Saldiri_Hedefi.transform.position); // Su noktaya git AI
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarakterler"))
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);

            _Gamemanager.YokOlmaEfektiOlustur(yeniPoz,false,true);

            gameObject.SetActive(false);
        }
    }

}