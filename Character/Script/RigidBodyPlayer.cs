using UnityEngine;
using System.Collections;

public class RigidBodyPlayer : MonoBehaviour {

	Rigidbody rig;
	// Use this for initialization
	public float speed=2f;
	public float verticalSpeed=4f;
	private Animator animator;
	private Vector3 forward=new Vector3(1,0,0);
	void Start () {
		rig = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
	}
	bool done=false;
	public float oldTime=0;

	public Vector3 moveTo;
	public bool canTurn=false;
	void FixedUpdate()
	{

		if (canTurn) {	
			TurnPlayer ();
		} else {

			MoveLeftRight();
		}
		//animator.SetFloat ("Direction", 0);


	}

	void MoveLeftRight ()
	{
		print (transform.forward);
		float z = Input.GetAxis ("Horizontal");
		// on z
		if (z == 0)
			moveTo = transform.forward;
		if (z > 0 && z != 0 && Time.time > oldTime) {
			//transform.RotateAround(transform.localPosition,Vector3.up,90);
			//transform.rotation=Quaternion.Euler(0,90,0);
			//rig.MovePosition (transform.position + transform.right * Time.deltaTime * speed);
			moveTo = transform.right+transform.forward;
			oldTime = Time.time + 0.5f;
			animator.SetFloat ("Direction", -1);
		}
		else
			if (z < 0 && z != 0 && Time.time > oldTime) {
				//transform.localRotation=Quaternion.Euler(0,-90,0);
				//transform.RotateAround(transform.localPosition,Vector3.up,-90);
				Vector3 left = transform.right;
				left.x = left.x > 0 ? -1 : 1;
				left.z = left.z > 0 ? -1 : 1;
				moveTo = -transform.right+transform.forward;
				oldTime = Time.time + 0.5f;
				//transform.Rotate(Quaternion.Euler(0,-90,0));
				animator.SetFloat ("Direction", 1);
			}
		rig.MovePosition (transform.position + moveTo * Time.deltaTime * speed);
	}

	void TurnPlayer ()
	{

		print (transform.forward);
		float z = Input.GetAxis ("Horizontal");
		// on z
		if (z > 0 && z != 0 && Time.time > oldTime) {
			transform.RotateAround (transform.localPosition, Vector3.up, 90);
			//transform.rotation=Quaternion.Euler(0,90,0);
			//rig.MovePosition (transform.position + transform.right * Time.deltaTime * speed);
			oldTime = Time.time + 0.5f;
			canTurn=false;

		}
		else
			if (z < 0 && z != 0 && Time.time > oldTime) {
				//transform.localRotation=Quaternion.Euler(0,-90,0);
				transform.RotateAround (transform.localPosition, Vector3.up, -90);
				oldTime = Time.time + 0.5f;
			canTurn=false;

				//transform.Rotate(Quaternion.Euler(0,-90,0));
			}
		rig.MovePosition (transform.position + transform.forward * Time.deltaTime * speed);
		//animator.SetFloat ("Direction", -1);
	}

	void FixedUpdate3()
	{


		print (transform.forward);
		float z=Input.GetAxis("Horizontal");// on z
		if (z > 0 && z!=0 && Time.time>oldTime) {
			transform.RotateAround(transform.localPosition,Vector3.up,90);
			//transform.rotation=Quaternion.Euler(0,90,0);
			//rig.MovePosition (transform.position + transform.right * Time.deltaTime * speed);
			oldTime=Time.time+0.5f;
		} else if(z<0 && z!=0 && Time.time>oldTime) {
			//transform.localRotation=Quaternion.Euler(0,-90,0);
			transform.RotateAround(transform.localPosition,Vector3.up,-90);
			oldTime=Time.time+0.5f;
			//transform.Rotate(Quaternion.Euler(0,-90,0));
		}
		rig.MovePosition (transform.position + transform.forward* Time.deltaTime * speed);
	}
	// Update is called once per frame
	void FixedUpdate2 () {



		if (Input.GetKey (KeyCode.E)&& canJump) {
			//rig.velocity += Vector3.up * verticalSpeed;
			rig.AddForce(new Vector3(0, verticalSpeed, 0), ForceMode.Impulse);
			animator.SetBool("jump",true);
		}
		float z=Input.GetAxis("Horizontal");// on z
		float x = Input.GetAxis ("Vertical");// on x
		float x2 = x > 0f ? 1 : -1;
		float z2 = z > 0f ? 1 : -1;
		print(Vector3.Scale(new Vector3(1, 2, 3), new Vector3(2, 3, 4)));
		print(Vector3.Cross(new Vector3(1, 2, 3), new Vector3(2, 3, 4)));
	print ( z*Vector3.forward + x*Vector3.right);
		if (z != 0 && x != 0 && canJump) {

			rig.MovePosition (transform.position + new Vector3 (z2, 0, x2) * Time.deltaTime * speed);
		} else {
					if (x != 0f) {
						rig.MovePosition(transform.position + new Vector3(0,0,x2*2)* Time.deltaTime*speed);
					}
					if (z != 0f) {
						rig.MovePosition (transform.position + new Vector3 (z2*2, 0, 0) * Time.deltaTime * speed);
					}
			

		
		}
	
	
	}
	public bool canJump=false;
	void OnTriggerEnter(Collider collider)
	{//Debug.Log ("asd");
		if (collider.CompareTag ("ground")) {
			canJump = true;	
		} else {
			canJump=false;
		}
		string tag = collider.tag;
		switch (tag) {
		case "turnpoint":canTurn=true; print("turn"); break;
			default:
				break;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.CompareTag ("ground")) {
			canJump = false;	
		} else {
			canJump=true;
		}
		string tag = collider.tag;
		switch (tag) {
		case "turnpoint":canTurn=false; print("turn exit"); break;
		default:
			break;
		}
	}
}
