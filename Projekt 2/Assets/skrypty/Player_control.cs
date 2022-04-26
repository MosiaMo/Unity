using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_control : MonoBehaviour
{
	private Rigidbody rb;
	public Transform camera;
	private float i=0;
	public float maxJump;
	public float minJump;
	public float JumpForce;
	private bool onGround=false;
	public float Threshold;

	// Start is called before the first frame update
	void Start()
    {
    rb=GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
	
	//poruszanie sie
	if (Input.GetAxis("Vertical")!=0||Input.GetAxis("Horizontal")!=0)
		{
		transform.rotation=Quaternion.Euler(0, camera.eulerAngles.y, 0);
		}		
    Vector3 move=Input.GetAxis("Vertical")*player_stats.Player.Speed.GetValue()*transform.forward*Time.deltaTime+Input.GetAxis("Horizontal")*player_stats.Player.Speed.GetValue()*transform.right*Time.deltaTime;
    rb.velocity=move+new Vector3(0,rb.velocity.y,0);
	
	//wykrywanie podlogi
	RaycastHit ground;
	for (float x=-0.5f; x<=0.5f; x+=0.5f)
		{
		for (float z=-0.5f; z<=0.5f; z+=0.5f)
			{
			Vector3 player_position=transform.position+new Vector3(x,0,z);
			if (Physics.Raycast(player_position,-Vector3.up,out ground,1f,1,QueryTriggerInteraction.Ignore))
				{
				onGround=true;
				break;
				} else
					{
					onGround=false;	
					}
			}
		}
	
	// skok
	if (onGround)
		{
		if (Input.GetButtonDown("Jump"))
			{
			rb.AddForce(new Vector3(0,minJump,0));			
			}	
		if (Input.GetButton("Jump")&&i<=maxJump)
			{
			i=i+i*Time.deltaTime;
			float tempJumpForce=JumpForce*Time.deltaTime;
			rb.AddForce(new Vector3(0,tempJumpForce,0));	
			}
		if (Input.GetButtonUp("Jump"))
			{
			i=0;	
			}
		}

	if (transform.position.y < Threshold)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	
	if (rb.velocity.y<0)
		{
		float tempFall=-450*Time.deltaTime;
		rb.AddForce(0,tempFall,0);
		}	

	if (Input.GetKeyDown(KeyCode.R))
		{
		PlayerInventory.instance.items.ForEach(x => x.Use());

		}		
	}
	
	void FixedUpdate()
	{
	
	}

	
}
