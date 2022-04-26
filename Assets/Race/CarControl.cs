using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
	public float obrot;
	public float acceleration;
	private Rigidbody rb;
	public float maxSpeed;
	public float dirtSpeed;
	private float speed;
	public float minSpeed;
	public float CorrectionForce;
	
    // Start is called before the first frame update
    void Start()
    {
    rb=GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
	float move=acceleration*Input.GetAxis("Vertical");
	if (move>0)
		{
		speed=maxSpeed;	
		}
	if (move<0)
		{
		speed=dirtSpeed;	
		}
	if (GetComponent<CarMechanics>().onGround>5)
		{
		speed=dirtSpeed;	
		}
	if (Mathf.Abs(transform.InverseTransformDirection(rb.velocity).z)<speed)
		{
		rb.AddRelativeForce(new Vector3(0,0,move));
		}
		
    float obracanie=Input.GetAxis("Horizontal")*obrot;
	transform.Rotate(new Vector3(0,obracanie,0));
    
	//sily pomocnicze
	if (transform.InverseTransformDirection(rb.velocity).z>speed+minSpeed)
		{
		rb.AddRelativeForce(new Vector3(0,0,-CorrectionForce));	
		}
	if (transform.InverseTransformDirection(rb.velocity).z<-speed-minSpeed)
		{
		rb.AddRelativeForce(new Vector3(0,0,CorrectionForce));	
		}
	if (transform.InverseTransformDirection(rb.velocity).x>minSpeed)
		{
		rb.AddRelativeForce(new Vector3(-CorrectionForce,0,0));	
		}
	if (transform.InverseTransformDirection(rb.velocity).x<-minSpeed)
		{
		rb.AddRelativeForce(new Vector3(CorrectionForce,0,0));	
		}	
	}
}
