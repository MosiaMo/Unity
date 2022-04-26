using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item_slot : MonoBehaviour, IPointerClickHandler
{
	public Item item;
	public Text item_name;
	
	void Start()
	{
	item_name.text=item.name;
	}
	
	public void DiscardItem()
	{
	PlayerInventory.instance.RemoveItem(item);
	Destroy(gameObject);
	}
	
	public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
		{
		}
		if (eventData.button == PointerEventData.InputButton.Right)
		{
		UImanager.instance.Selected=gameObject;
		item.Use();
		}
	}
}
