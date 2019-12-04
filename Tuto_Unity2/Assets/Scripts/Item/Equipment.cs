using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

[CreateAssetMenu(fileName = "New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;
    public int armorModifier; //increse/decrease in armor
    public int damageModifier; //increase/decrease in damage

    public override void Use() {
        base.Use();
        EquipmentManager.instance.Equip(this); //equip item
        RemoveFromInventory(); //remove from inventory
    }

}

public enum EquipmentSlot {Head, Chest, Legs, Weapon, Shield, Feet}
public enum EquipmentMeshRegion{Legs, Arms, Torso}; //corresponds to body blendshapes