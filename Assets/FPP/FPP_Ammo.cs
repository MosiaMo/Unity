using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPP_Ammo : MonoBehaviour
{
 	public float speed;
	public int Lifespan;
	private int i;

    // Update is called once per frame
    void FixedUpdate()
    {
    i++;
	if (i>Lifespan)
		{
		Destroy(gameObject);
		}
	Vector3 move=speed*transform.forward;	
	GetComponent<Rigidbody>().velocity=move;
    }
	
	void OnCollisionEnter(Collision hit)
	{
	if (hit.gameObject.CompareTag("enemy"))
		{
		//Destroy(hit.gameObject);
		}		
	Destroy(gameObject);	
	}
}
