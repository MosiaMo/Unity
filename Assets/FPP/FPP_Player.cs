using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPP_Player : MonoBehaviour
{
	public float speed;
	public float jumpForce;
	private Rigidbody rb;
	private bool onGround;
    // Start is called before the first frame update
    void Start()
    {	
    rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
	RaycastHit ground;
	
	for (float x=-0.45f; x<=0.45f; x+=0.225f)
		{
		Vector3 pozycja=transform.position+new Vector3(x,0,0);
		Debug.DrawRay(pozycja, -Vector3.up, Color.red,0.1f);
		if (Physics.Raycast(pozycja, new Vector3(0,-1,0), out ground, 1.2f, 1, QueryTriggerInteraction.Ignore))
			{
			if (ground.collider.gameObject.CompareTag("enemy"))
				{
				Destroy(ground.collider.gameObject);
				Jump();
				break;
				}
			onGround=true;
			break;
			} else
				{
				onGround=false;
				}
		}
	
	if (Input.GetButtonDown("Jump")&&onGround)
		{
		Jump();	
		}
    }
	
	void FixedUpdate()
	{
	Vector3 move=speed*Input.GetAxis("Horizontal")*transform.right+speed*Input.GetAxis("Vertical")*transform.forward;
	rb.velocity=new Vector3(0,rb.velocity.y,0)+move;
	}
	
	void Jump()
	{
	rb.velocity=new Vector3(rb.velocity.x,0,0);	
	rb.AddForce(new Vector3(0,jumpForce,0));	
	}
}
