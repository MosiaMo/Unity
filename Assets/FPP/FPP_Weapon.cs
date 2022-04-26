using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPP_Weapon : MonoBehaviour
{
	public Vector3 offset;
	public Transform player;
	public GameObject ammo;
    // Update is called once per frame
    void LateUpdate()
    {
    transform.rotation=player.rotation*Quaternion.Euler(90,0,0);
	
	float AngleY=player.eulerAngles.y;
	float AngleX=player.eulerAngles.x;
	Quaternion Obracanie=Quaternion.Euler(AngleX,AngleY,0);
	transform.position=player.position+Obracanie*offset;
    }
	
	void Update()
	{
	if (Input.GetButtonDown("Fire1"))
		{
		Vector3 pozycja=transform.position+transform.up;
		Instantiate(ammo,pozycja,transform.rotation*Quaternion.Euler(-90,0,0));	
		}	
	}
}
