using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public int pointValue; 
    private LevelManager manager;
	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        if (manager == null)
        {
            print("manager is null");
        }
	}
    private bool oneTime=false;
   void OnTriggerEnter(Collider collider)
    {
       
        if (collider.CompareTag("RealPlayer") & oneTime==false)
        {
          
            oneTime = true;
            // Destroy(gameObject);
            gameObject.SetActive(false);
            manager.AddPoint(pointValue);

        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
