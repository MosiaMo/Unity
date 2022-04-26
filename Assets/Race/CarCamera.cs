using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCamera : MonoBehaviour
{
	public Vector3 offset;
	public Transform player;
    // Update is called once per frame
    void FixedUpdate()
    {
    transform.LookAt(player.position);
	
	float Angle=player.eulerAngles.y;
	Quaternion Obracanie=Quaternion.Euler(0,Angle,0);
	transform.position=player.position+Obracanie*offset;
    }
}
