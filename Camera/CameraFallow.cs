using UnityEngine;
using System.Collections;

public class CameraFallow : MonoBehaviour {

    public GameObject player;
    public float speed=0.1f;
    public Rigidbody rig;
    public Rigidbody playerRig;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRig = player.GetComponent<Rigidbody>();
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rig.MovePosition(player.transform.forward * Time.time * speed);
	}
}
