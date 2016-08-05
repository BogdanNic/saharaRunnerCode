using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ThirdPersonRunner))]
public class ThirdPersonRunnerControl : MonoBehaviour {

	ThirdPersonRunner person;
	private Vector3 moveTo=new Vector3(0f,0f,0f);
	private bool jump=false;
	private bool slide=false;
	private float oldTime=0f;
	public float timeDist;
	void Start () {
		person=GetComponent<ThirdPersonRunner>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate()
	{
		moveTo=Vector3.zero;
		if(Time.time>oldTime){
			float x=Input.GetAxis("Vertical");
			float z = Input.GetAxis ("Horizontal");
			
			if(z==0f)
			{
				jump=false;
				slide=false;
			}
			if(x>0f){
				jump=true;
				slide=false;
			}else if(x<0f){
				slide=true;
				jump=false;
			}
			oldTime=Time.time+timeDist;
			moveTo.z=z;
		}
		person.Move(moveTo, jump,slide);	

	}

}
