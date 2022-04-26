using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarMechanics : MonoBehaviour
{
	public Text LapsString;
	public Text EndString;
	public Text VelocityString;
	public Text TotalTimeString;
	public Text CurrentTimeString;
	public Text BestTimeString;
	
	private int Laps=0;
	public int Goal;
	private float TotalTime=0;
	private float CurrentTime=0;
	private float BestTime=float.MaxValue;
	private bool PK1=true;
	private bool PK2=true;
	public int onGround=0;
    // Start is called before the first frame update
    void Start()
    {
    LapsString.text="Laps: "+Laps.ToString("F0")+"/"+Goal.ToString("F0");
	EndString.text="Cross the finish line to start!";
	TotalTimeString.text="Total time: "+(TotalTime/50).ToString("F2");
	CurrentTimeString.text="Total time: "+(CurrentTime/50).ToString("F2");
	BestTimeString.text="Best time: --.--";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
	onGround=0;	
	RaycastHit ground;
	for (float x=-0.7f; x<=0.7f; x+=1.4f)
		{
		for (float z=-1.4f; z<=1.4f; z+=2.8f)
			{
			Vector3 pozycja=transform.position+transform.forward*z+transform.right*x;	
			if (Physics.Raycast(pozycja, -Vector3.up,out ground, 0.6f))
				{
				if (ground.collider.tag=="Ground")
					{
					onGround++;	
					}
				onGround++;	
				}			
			}		
		}
	
	if (onGround==0)
		{
		GetComponent<CarControl>().enabled=false;	
		} else
			{
			GetComponent<CarControl>().enabled=true;	
			}
	
	VelocityString.text=transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z.ToString("F0");
	
	if (Laps>0&&Laps<=Goal)	
		{
		TotalTime++;
		CurrentTime++;
		if (CurrentTime>100)
			{
			EndString.text="";	
			}
		TotalTimeString.text="Total time: "+(TotalTime/50).ToString("F2");
		CurrentTimeString.text="Total time: "+(CurrentTime/50).ToString("F2");
		}
	if (Laps>Goal)
		{
		EndString.text="You finished the race!\nYour total time was: "+(TotalTime/50).ToString("F2")+"\nYout best lap was: "+(BestTime/50).ToString("F2")+"\nPress 'space' to restart.";
		if (Input.GetButtonDown("Jump"))
			{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);	
			}
		}
    }
	
	void OnTriggerEnter(Collider meta)
	{
	if (meta.gameObject.CompareTag("enemy"))
		{
		PK1=true;	
		}	
	if (meta.gameObject.CompareTag("coin")&&PK1)
		{
		PK2=true;	
		}	
	if (meta.gameObject.CompareTag("Finish")&&PK1&&PK2)
		{
		if (Laps>0)
			{
			if (CurrentTime<BestTime)
				{
				BestTime=CurrentTime;
				BestTimeString.text="Best time: "+(BestTime/50).ToString("F2");
				}
			}	
		Laps++;
		LapsString.text="Laps: "+Laps.ToString("F0")+"/"+Goal.ToString("F0");
		EndString.text="Next lap!\n"+(Goal+1-Laps).ToString("F0")+" lap(s) left!";
		PK1=false;
		PK2=false;
		}	
	}
}
