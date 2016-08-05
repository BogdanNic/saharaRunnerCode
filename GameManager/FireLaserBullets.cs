using UnityEngine;
using System.Collections;

public class FireLaserBullets : MonoBehaviour {

    public Transform firePosition;
    public GameObject fireHoll;
    public GameObject LaserObject;
    public bool CanFire=false;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (CanFire)
        {
            RaycastHit hit;
            Instantiate(LaserObject, firePosition.position, firePosition.rotation);

            Ray ray = new Ray(firePosition.position, firePosition.forward);
            if (Physics.Raycast(ray,out hit,100f))
            {
                Instantiate(fireHoll,hit.point,
                    Quaternion.FromToRotation(Vector3.up,hit.normal));
            }
        }
	}
}
