using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPP_Camera : MonoBehaviour
{
    private Vector2 mouseLook;
	public float sensitivity;
	public Transform player;

    void Start()
	{
	Cursor.lockState=CursorLockMode.Locked;
	}

	// Update is called once per frame
    void Update()
    {
    Vector2 temp=new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"))*sensitivity;
	mouseLook+=temp;
	mouseLook.y=Mathf.Clamp(mouseLook.y,-70,70);
	transform.localRotation=Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
	player.rotation=Quaternion.AngleAxis(mouseLook.x, player.up);
	
	if (Input.GetKeyDown(KeyCode.Escape))
		{
		Cursor.lockState=CursorLockMode.None;
		}
	}
}
