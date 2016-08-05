using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class PlayerSetup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
       
        switch (indexScene)
        {
            case 0: MainMenu(); break;
            case 1:
                //StartPlaying(); 
                print("playing"); break;
         
        }
    }

    public void MainMenu()
    {
        GetComponent<ThirdPersonRunner>().enabled = false;
        GetComponent<ThirdPersonTouchControl>().enabled = false;
        if (GetComponent<ThirdPersonRunner>().isActiveAndEnabled)
        {
            print("is runindf");

        }
    }

    public void StartPlaying()
    {
        gameObject.SetActive(true);
        GetComponent<ThirdPersonRunner>().enabled = true;
        GetComponent<ThirdPersonTouchControl>().enabled = true;
        if (GetComponent<ThirdPersonRunner>().isActiveAndEnabled)
        {
            print("is runindf");
            
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
