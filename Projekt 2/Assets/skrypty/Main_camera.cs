using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_camera : MonoBehaviour
{
	public Vector3 offset;
	private Vector2 mouse_pos;
	public float sensitivity;
	public Transform gracz;
	
    // Start is called before the first frame update
    void Start()
    {
    Cursor.lockState=CursorLockMode.Locked;
	transform.position=gracz.position+offset;    
    }

    // Update is called once per frame
    void Update()
    {
	if (Input.GetKeyDown(KeyCode.Escape))
		{	
		Cursor.lockState=CursorLockMode.None;    
		}
		
	Vector2 mouse_look=new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"))*sensitivity*Time.deltaTime;
	mouse_pos+=mouse_look;
	mouse_pos.y=Mathf.Clamp(mouse_pos.y,-70,70);
	
	Quaternion rotate=Quaternion.AngleAxis(mouse_pos.x,Vector3.up)*Quaternion.AngleAxis(-mouse_pos.y,Vector3.right);
	transform.position=gracz.transform.position+rotate*offset;
	
	Vector3 look=gracz.position-transform.position+new Vector3(0,offset.y,0);
	transform.rotation=Quaternion.LookRotation(look);
	}
}
