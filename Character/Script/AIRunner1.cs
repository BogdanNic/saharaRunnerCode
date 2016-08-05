using UnityEngine;
using System.Collections;

public class AIRunner1 : MonoBehaviour {

	NavMeshAgent agent;
	public Transform target;
	public Transform pos;
//	private ThirdPersonRunner character;
//	public Vector3 v1=new Vector3(1,0,0);
//	public Vector3 v2=new Vector3(1,0,0);
//	public Vector3 vr=new Vector3(0,0,0);
	// Use this for initialization
	void Start () {
		//character=GetComponent<ThirdPersonRunner>();
		agent=GetComponent<NavMeshAgent>();
	
		agent.updateRotation = false;
		agent.updatePosition = true;
	
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null)
		{
			agent.SetDestination(target.position);
			
			//Vector2 fromVector2 = new Vector2(0, 1);
			//Vector2 toVector2 = new Vector2(-1, 0);
			
			//float ang = Vector3.Angle(v1,v2);
			//print (ang);
			//Vector3 cross = Vector3.Cross(transform.right,target.position);
			//vr=cross;
//			if (cross.z > 0)
//				ang = 360 - ang;

			//print(cross);
			//print(transform.forward);
			//print(agent.desiredVelocity);
			//print(agent.desiredVelocity.normalized-transform.forward);
			//print(agent.desiredVelocity.normalized+transform.right);
			pos.transform.Translate(agent.desiredVelocity*Time.deltaTime);
			// use the values to move the character
			//character.Move(-cross.normalized, false, false);

		}
	}
}
