using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

	new public string name = "New Item";
	
	public virtual void Use()
	{
	
	}
}
