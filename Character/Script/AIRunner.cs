using UnityEngine;
using System.Collections;

public class AIRunner : MonoBehaviour {

	NavMeshAgent agent;
	public Transform target;
	private ThirdPersonRunner character;
	public Vector3 v1=new Vector3(1,0,0);
	public Vector3 v2=new Vector3(1,0,0);
	public Vector3 vr=new Vector3(0,0,0);
	// Use this for initialization
	void Start () {
		character=GetComponent<ThirdPersonRunner>();
		agent=GetComponent<NavMeshAgent>();
	
		agent.updateRotation = false;
		agent.updatePosition = false;
	
	}
	// Update is called once per frame
	void FixedUpdate () {
		character.Move(Vector3.zero, false, false);
	}
	
	// Update is called once per frame
	void FixedUpdate2 () {
		if (target != null)
		{
			agent.SetDestination(target.position);
			
			//Vector2 fromVector2 = new Vector2(0, 1);
			//Vector2 toVector2 = new Vector2(-1, 0);
			
			float ang = Vector3.Angle(v1,v2);
			//print (ang);
			Vector3 cross = Vector3.Cross(transform.right,target.position);
			vr=cross;
			if (cross.z > 0)
				ang = 360 - ang;

			//print(cross);
			Vector3 moveTo=agent.desiredVelocity.normalized-transform.forward;
			Debug.Log(Mathf.Cos(transform.position.x/Vector3.Distance(target.position,target.position)));
			moveTo.x=(int)moveTo.x;
			moveTo.y=0;
			moveTo.z=(int)moveTo.z;
			print(moveTo);
			//print(agent.desiredVelocity);
			//this.transform.Translate(agent.desiredVelocity);
			// use the values to move the character

			character.Move(moveTo, false, false);
			moveTo.x=(int)v1.x;
			moveTo.y=(int)v1.y;
			moveTo.z=(int)v1.z;
			print(moveTo);
		}
	}
	void OnTriggerEnter()
	{

	}
}
