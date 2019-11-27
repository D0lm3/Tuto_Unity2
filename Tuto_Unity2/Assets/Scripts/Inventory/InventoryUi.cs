﻿using UnityEngine;

public class InventoryUi : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    Inventory inventory;
    // Start is called before the first frame update

    InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory")){
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI(){
        for(int i = 1; i < slots.Length; i++){
            if(i < inventory.items.Count){
                slots[i].AddItem(inventory.items[i]);
            }else{
                slots[i].ClearSlot();
            }
        }
    }
}
