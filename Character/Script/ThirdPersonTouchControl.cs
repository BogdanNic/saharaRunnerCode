using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ThirdPersonRunner))]
public class ThirdPersonTouchControl : MonoBehaviour {

   
	public TouchPadBog pad;
	public float timeDist;


	private Vector3 moveTo=new Vector3(0f,0f,0f);
	private bool jump=false;
	private bool slide=false;
	private float oldTime=0f;
	ThirdPersonRunner person;

	void Start () {
		person=GetComponent<ThirdPersonRunner>();
       
	}
	
    void OnEnable()
    {
        GameObject padObj = GameObject.FindGameObjectWithTag("TouchPad");
        if (padObj != null)
        {
            pad = padObj.GetComponent<TouchPadBog>();
        }


        if (pad == null)
        {
            print("no touch pad define");
        }
        print("enabled");
    }

	void FixedUpdate()
	{
        if (pad == null)
        {
            print("pad is null");
            return;
        }
       
		Vector3 movemend=pad.GetDirection ();
		float x=movemend.x;
		float y=movemend.y;
		if (x != 0.0f && y != 0.0f) {
			if (Mathf.Abs (x) - Mathf.Abs (y)> 0.1f) {
				//mobe vertical
				if(x>0.1f)
				{
					//v=0f;
					moveTo.z=1f;
					//Debug.Log("move verical stanga ");
				}else{
					//v=0f;
					moveTo.z=-1f;
					//Debug.Log("move verical dreapta");
				}
				
				
			} else {
				if(y>0.1f)
				{ 
					jump=true;
				}else{
					slide=true;
				}
			}
		}
		person.Move(moveTo, jump,slide);

		slide=false;
		jump=false;
		moveTo=Vector3.zero;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
