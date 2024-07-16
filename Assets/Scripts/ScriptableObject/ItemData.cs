using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon; // Иконка предмета
    public int stackSize = 5; // Размер стака предмета (количество предметов в стаке)
}