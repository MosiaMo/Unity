using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : player_stats
{
	public static PlayerEquipment instance;
	
	void Awake()
	{
		instance=this;
	}
	
	public Equipment[] currentEquipment;
	public GameObject EquipmentSlot;
	
    // Start is called before the first frame update
    void Start()
    {
    int EquipSlots = System.Enum.GetNames(typeof(EquipmentType)).Length;
	currentEquipment=new Equipment[EquipSlots];
    }

	public void EquipItem (Equipment newItem)
	{
		int slotIndex = (int)newItem.Type;	
		
		if (currentEquipment[slotIndex]!=null)
			{
			Equipment oldItem=currentEquipment[slotIndex];
			PlayerInventory.instance.AddItem(oldItem);
			player_stats.Player.Speed.RemoveModifier(oldItem.Speed);
			player_stats.Player.Health.RemoveModifier(oldItem.Health);
			player_stats.Player.Mana.RemoveModifier(oldItem.Mana);
			player_stats.Player.Strength.RemoveModifier(oldItem.Strength);
			player_stats.Player.Magic.RemoveModifier(oldItem.Magic);
			player_stats.Player.Defence.RemoveModifier(oldItem.Defence);
			player_stats.Player.Luck.RemoveModifier(oldItem.Luck);
			Destroy(UImanager.instance.EquipmentSlots[slotIndex].GetChild(0).gameObject);
			currentEquipment[slotIndex]=newItem;
			} else
				{
				currentEquipment[slotIndex]=newItem;
				}
		player_stats.Player.Speed.AddModifier(newItem.Speed);
		player_stats.Player.Health.AddModifier(newItem.Health);
		player_stats.Player.Mana.AddModifier(newItem.Mana);
		player_stats.Player.Strength.AddModifier(newItem.Strength);
		player_stats.Player.Magic.AddModifier(newItem.Magic);
		player_stats.Player.Defence.AddModifier(newItem.Defence);
		player_stats.Player.Luck.AddModifier(newItem.Luck);
		var newSlot=Instantiate(EquipmentSlot,UImanager.instance.EquipmentSlots[slotIndex]);
		newSlot.GetComponent<Equipment_slot>().item=newItem;
	}
	
	public void UnequipItem(Equipment oldItem)
	{
		int slotIndex = (int)oldItem.Type;
		PlayerInventory.instance.AddItem(oldItem);
		player_stats.Player.Speed.RemoveModifier(oldItem.Speed);
		player_stats.Player.Health.RemoveModifier(oldItem.Health);
		player_stats.Player.Mana.RemoveModifier(oldItem.Mana);
		player_stats.Player.Strength.RemoveModifier(oldItem.Strength);
		player_stats.Player.Magic.RemoveModifier(oldItem.Magic);
		player_stats.Player.Defence.RemoveModifier(oldItem.Defence);
		player_stats.Player.Luck.RemoveModifier(oldItem.Luck);
		Destroy(UImanager.instance.EquipmentSlots[slotIndex].GetChild(0).gameObject);
		currentEquipment[slotIndex]=null;
	}


}
