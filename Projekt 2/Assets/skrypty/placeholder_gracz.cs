using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeholder_gracz : MonoBehaviour
{
    private Rigidbody rb;
	public float speed;
	public float jumpforce;
	public Transform camera;
	
	// Start is called before the first frame update
    void Start()
    {
    rb=GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    Vector3 move=transform.right*Input.GetAxis("Horizontal")*speed+Input.GetAxis("Vertical")*transform.forward*speed;
	rb.velocity=move+new Vector3(0,rb.velocity.y,0);
	
	if (Input.GetAxis("Horizontal")==0&&Input.GetAxis("Vertical")==0)
		{
		//powrót kamery do pozycji początkowej	
		} else
			{
			transform.rotation=Quaternion.Euler(0,camera.transform.eulerAngles.y,0);
			}
    }
}

//Unity 2018.4.36f1