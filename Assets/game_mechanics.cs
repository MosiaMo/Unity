using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_mechanics : MonoBehaviour
{
	private int coinCount=0;
	public bool Dead=false;
	private bool Win=false;
	public Text endString;
	public Text coinString;
	public float Threshold;
	
	void Start()
	{
	endString.text="";
	coinString.text="Coins: "+coinCount.ToString("F0");	
	}
	
	void Update()
	{
	if (transform.position.y<Threshold)
		{
		Dead=true;	
		}
		
	if (Dead)
		{
		endString.text="You died! Press 'space' to restart.";	
		Destroy(GetComponent<player_control>());
		Destroy(GetComponent<Rigidbody>());
		Destroy(GetComponent<Collider>());
		Destroy(GetComponent<Renderer>());
		if (Input.GetButtonDown("Jump"))
			{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);	
			}
		}	
	
	if (Win)
		{
		endString.text="You won! Press 'space' to restart.";	
		Destroy(GetComponent<player_control>());
		Destroy(GetComponent<Rigidbody>());
		Destroy(GetComponent<Collider>());
		if (Input.GetButtonDown("Jump"))
			{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);	
			}
		}	
		
	}
	
	void OnTriggerEnter(Collider collect)
	{
	if (collect.gameObject.CompareTag("coin"))
		{
		coinCount++;
		coinString.text="Coins: "+coinCount.ToString("F0");	
		Destroy(collect.gameObject);
		}	
	if (collect.gameObject.CompareTag("Finish"))
		{
		Win=true;	
		}
	}
}
