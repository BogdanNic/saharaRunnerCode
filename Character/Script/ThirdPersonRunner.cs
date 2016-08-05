using UnityEngine;

using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class ThirdPersonRunner : MonoBehaviour {

	Rigidbody rig;
	Animator animator;
	public float speed=5f;
	public float jumpSpeed=1f;
	public float verticalSpeed=2f;
	public bool isGrounded=false;
	public float distanceToGround=1f;
	public float upDistance=10f;
	public BoxCollider box_capsule;
    public GameObject box;
	private float aniSpeed;
	//public float aniSpeed2;
	private bool canTurn=false;
	private Vector3 dir2;
	private bool m_slide;
	private float capsule_height;
	private float capsule_center;
	public bool hasWall=false;
	private bool m_jump;
    private Vector3 localScale;
    private Vector3 positionRealPlayer;
    private int jumpAnimHash = Animator.StringToHash("jumping");
    private bool skip = false;
	void Start () {
		rig=GetComponent<Rigidbody>();
		animator=GetComponent<Animator>();
        localScale = box.transform.localScale;
        positionRealPlayer = box.transform.position;
		//box_capsule=GetComponent<BoxCollider>();//Get Real Body
		capsule_center=box_capsule.center.y;
		capsule_height=box_capsule.size.y;
	}
	void Update()
	{
		//animator.SetFloat("speed",Mathf.Lerp(aniSpeed,0f,Time.deltaTime));
	}
	public void Move(Vector3 direction,bool jump,bool slide)
	{
        if (rig==null)
        {
            return;
        }
		CheckForGround ();
		if(direction==Vector3.zero)
		{
            skip = false;
			aniSpeed=0f;
		}
		if (canTurn && direction!=Vector3.zero) {
			//turn charcacter
			if (direction.z>0) {
				canTurn=false;
				aniSpeed=-1f;
                print(transform.position);
                transform.RotateAround (transform.position, Vector3.up, 90);
                print("left"+transform.position);
                skip = true;
            }
            else if(direction.z<0){
				canTurn=false;
				aniSpeed=1f;
                print("right" + transform.position);
                print(transform.position);
                transform.RotateAround (transform.position, Vector3.up, -90);
                print(transform.position);
                skip = true;
            }
		}else{
			//move right /left
			if(direction.z>0f){
				aniSpeed=-1f;
				//direction =transform.right*verticalSpeed;
				animator.SetTrigger("right");
            
				if(hasWall)
				{
					print("run wall");
					direction=transform.up*upDistance;
					rig.useGravity=false;
					animator.SetTrigger("wallRun");
				}else{
					rig.useGravity=true;
					direction =transform.right*verticalSpeed;

				}
			
			}else if(direction.z<0f){
				animator.SetTrigger("left");
              
                if (hasWall)
				{
					print("run wall");
					direction=transform.up*upDistance;
					rig.useGravity=false;
					animator.SetTrigger("wallRun");
				}else{
					rig.useGravity=true;
					direction = -transform.right*verticalSpeed;
				}


			}
		}

	
		if(jump && isGrounded)
		{
			//print("jump");
			rig.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            ScaleCapusleForJump();
			m_jump=true;
		
		}else
		{
			m_jump=false;
            if (!skip)
            {
                rig.MovePosition(transform.position+(transform.forward+direction)*Time.deltaTime*speed);
            }
           // print("skip"+skip);
			
		}
		if(slide)
		{
			ScaleCapusleForSlide();
		}
       
        ResetCapsule();
		m_slide=slide;
        //	aniSpeed2=aniSpeed;
        m_jump = jump;
		Animate();
	}

    private void ScaleCapusleForJump()
    {
        box.transform.localScale = new Vector3(localScale.x, 0.9f, localScale.z);
    }

    private void ResetCapsule()
    {
        float sizeCurve = animator.GetFloat("ColliderSize");
     
        if (sizeCurve==0f && Math.Floor(rig.velocity.y)<0.2f)
        {
            box.transform.localScale = localScale;
            box.transform.localPosition = positionRealPlayer;
        }
        
        
    }
    
    private void Animate()
	{
		//print(rig.velocity.y);
		animator.SetBool("IsGround",isGrounded);
		animator.SetFloat("vSpeed",rig.velocity.y);
		//animator.SetTrigger("jump");
		if(m_jump)
		{
			animator.SetTrigger("jump");
		}
		animator.SetBool("slide",m_slide);
	}
	void ScaleCapusleForSlide()
	{
		float sizeCurve = animator.GetFloat ("ColliderSize");
        if (sizeCurve!=0f)
        {
            box.transform.localScale = new Vector3(localScale.x, 0.5f, localScale.z);
           // box.transform.localPosition = new Vector3(0f, positionRealPlayer.y, 0f);

        }
	}
    private void ResetCapsule2()
    {
        float sizeCurve = animator.GetFloat("ColliderSize");
        if (sizeCurve == 0f)
            box_capsule.center = Vector3.zero;

    }
    void ScaleCapusleForSlide2()
    {
        float sizeCurve = animator.GetFloat("ColliderSize");
        float newYcenter = -0.63f;

        float lerpCenter = Mathf.Lerp(0, newYcenter, sizeCurve);
        box_capsule.center = new Vector3(0, lerpCenter, 0);

        box_capsule.size = new Vector3(1f, Mathf.Lerp(capsule_height, 1f, sizeCurve), 1f);
    }
    void CheckForGround ()
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit, distanceToGround)) {
			//distanceToGround = hit.distance;
			isGrounded = true;
		}
		else {
			isGrounded = false;
		}
	}

	void OnTriggerEnter(Collider collider)
	{
       // print(collider.name);

		string tag = collider.tag;
		switch (tag) {
	        
			case "turnpoint":canTurn=true; print("turn"); break;
			case "wall":hasWall=true; print("wall"); break;
		default:
                //print(collider.tag);
			break;
		}
	}
	void OnTriggerExit(Collider collider)
	{
		
		string tag = collider.tag;
		switch (tag) {
			case "turnpoint":canTurn=false; print("turn exit"); break;
		case "wall":hasWall=false; print("no wall");rig.useGravity=true; animator.SetBool("wallRun",false); break;
		default:
			break;
		}
	}
    void OnParticleCollision(GameObject other)
    {
        print("particale");
       // Destroy(gameObject);
    }

}
