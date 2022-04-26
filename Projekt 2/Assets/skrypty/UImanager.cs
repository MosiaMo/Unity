using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
	public static UImanager instance;
	
	void Awake()
	{
	instance=this;
	}
	
	public GameObject Selected;
	
	public GameObject InventoryScreen;
	public GameObject EquipmentScreen;
	
	public Transform[] EquipmentSlots;
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
		{
			if (InventoryScreen.activeSelf==false)
			{
			InventoryScreen.SetActive(true);
			Cursor.lockState=CursorLockMode.None;		
			} else
				{
				DisableInventoryScreen();
				}
		} 
		if (Input.GetButtonDown("Equipment"))
		{
			if (EquipmentScreen.activeSelf==false)
			{
			EquipmentScreen.SetActive(true);
			Cursor.lockState=CursorLockMode.None;		
			} else
				{
				DisableEquipmentScreen();
				}
		} 
    }
	
	public void DisableInventoryScreen()
	{
	InventoryScreen.SetActive(false);
	if (EquipmentScreen.activeSelf==true)
		{
		Cursor.lockState=CursorLockMode.Locked;
		}
	}
	
	public void DisableEquipmentScreen()
	{
	EquipmentScreen.SetActive(false);
	if (InventoryScreen.activeSelf==true)
		{
		Cursor.lockState=CursorLockMode.Locked;	
		}
	}
}
