using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	public static PlayerInventory instance;
	
	void Awake()
	{
	instance=this;	
	}
	
	public GameObject InventorySlot;
	public GameObject InventoryList;
	
	public List<Item> items=new List<Item>();
	
	public void AddItem(Item newItem)
	{
		items.Add(newItem);
		var newSlot=Instantiate(InventorySlot,InventoryList.transform);
		newSlot.GetComponent<Item_slot>().item=newItem;
	}
 
	public void RemoveItem(Item newItem)
	{
		items.Remove(newItem);
	}
 
}
