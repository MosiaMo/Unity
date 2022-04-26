using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPP_turret : MonoBehaviour
{
	public Transform tower;
	public GameObject ammo;
	public float Range;
	public float FireRate;
	private Transform player;
	private int i;
	
    // Start is called before the first frame update
    void Start()
    {
    player=GameObject.FindWithTag("Player").transform;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    if (Vector3.Distance(transform.position, player.position)<Range)
		{
		i++;
		Vector3 pozycjaGracza=player.position-tower.position;
		Vector3 obrot=Vector3.RotateTowards(tower.forward,pozycjaGracza,0.025f,0.0f);
		tower.rotation=Quaternion.LookRotation(obrot);
		if (i>FireRate)
			{
			Vector3 pozycja=tower.GetChild(0).transform.position+tower.forward;	
			Instantiate(ammo,pozycja,tower.rotation);
			i=0;
			}
		} else
			{
			i=0;
			Vector3 obrot=Vector3.RotateTowards(tower.forward,Vector3.forward,0.025f,0.0f);
			tower.rotation=Quaternion.LookRotation(obrot);
			}
    }
}
