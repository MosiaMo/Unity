using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{

	public EquipmentType Type;
	
	public float Speed;
	public float Health;
	public float Mana;
	public float Strength;
	public float Magic;
	public float Defence;
	public float Luck;
	
	public override void Use()
	{
	PlayerEquipment.instance.EquipItem(this);
	PlayerInventory.instance.RemoveItem(this);
	Destroy(UImanager.instance.Selected);
	}	
}

public enum EquipmentType{Helm,Chest,Arms,Legs,RightHand,LeftHand};
