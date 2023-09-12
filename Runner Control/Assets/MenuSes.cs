using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSes : MonoBehaviour
{
    private static GameObject instance;

   public AudioSource Ses;

    // Start is called before the first frame update
    void Start()
    {
       
       // Ses.volume = PlayerPrefs.GetFloat("MenuSes"); // buraya gelicem
        DontDestroyOnLoad(gameObject); // bu objeyi sahneler arasinda gecislerde kaybetmiceksin dedik.

        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
