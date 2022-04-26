using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{	
	public float speed;
	private int Direction;
	public int Lifespan;
	private int i;
    // Start is called before the first frame update
    void Start()
    {
    Direction=GameObject.FindWithTag("Player").GetComponent<player_control>().side;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    i++;
	if (i>Lifespan)
		{
		Destroy(gameObject);
		}
	float move=Direction*speed;
	GetComponent<Rigidbody>().velocity=new Vector3(move,GetComponent<Rigidbody>().velocity.y,0);
    }
	
	void OnCollisionEnter(Collision hit)
	{
	if (hit.gameObject.CompareTag("enemy"))
		{
		Destroy(hit.gameObject);
		}		
	Destroy(gameObject);	
	}
}
