using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
	public List<Item> items=new List<Item>();
	
	void OnTriggerStay(Collider contener)
	{
		if (contener.gameObject.CompareTag("Player"))
		{
			if (Input.GetKeyDown(KeyCode.E))
				{
				items.ForEach(x => PlayerInventory.instance.AddItem(x));
				items.Clear();
				}
		}
	}
}
