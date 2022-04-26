using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
	public float speed;
	public float jumpForce;
	private Rigidbody rb;
	private bool onGround;
	public int side=1;
	public GameObject ammo;
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
		if (Physics.Raycast(pozycja, new Vector3(0,-1,0), out ground, 0.6f, 1, QueryTriggerInteraction.Ignore))
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
	if (Input.GetButtonDown("Fire1"))
		{
		Vector3 pozycjaStrzalu=transform.position+new Vector3(side,0,0);
		Instantiate (ammo,pozycjaStrzalu,transform.rotation);
		}
    }
	
	void FixedUpdate()
	{
	float move=speed*Input.GetAxis("Horizontal");
	if (move>0)
		{
		side=1;	
		}
	if (move<0)
		{
		side=-1;	
		}
	rb.velocity=new Vector3(move,rb.velocity.y,0);
	}
	
	void Jump()
	{
	rb.velocity=new Vector3(rb.velocity.x,0,0);	
	rb.AddForce(new Vector3(0,jumpForce,0));	
	}
}
