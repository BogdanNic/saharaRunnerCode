using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

    private LevelManager manager;
    private int trapType = 1;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        if (manager == null)
        {
            print("manager is null");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        
        if (collider.CompareTag("RealPlayer"))
        {

            manager.HitTrap(trapType);
        }
    }
}
