using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment_slot : MonoBehaviour
{
	public Equipment item;
	public Text item_name;
	
	void Start()
	{
	item_name.text=item.name;
	}
	
	public void RemoveItem()
	{
	PlayerEquipment.instance.UnequipItem(item);
	}
}
