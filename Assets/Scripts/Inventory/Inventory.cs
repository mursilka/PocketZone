using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform[] Slots; // Ссылки на слоты инвентаря

    void Start()
    {
        // Инициализация слотов
        foreach (Transform slot in Slots)
        {
            ClearSlot(slot);
        }
    }

    public bool AddItem(Item newItem)
    {
        foreach (Transform slotTransform in Slots)
        {
            InventorySlot slot = slotTransform.GetComponent<InventorySlot>();

            if (slot != null)
            {
                // Если слот занят и предметы одинаковые по имени и не превышают максимальный стак,
                // то увеличиваем количество в стаке
                if (slot.IsOccupied() && slot.CurrentItemData != null && slot.CurrentItemData.itemName == newItem.itemData.itemName)
                {
                    if (slot.CurrentStackCount < slot.CurrentItemData.stackSize) // Проверяем, не превышено ли максимальное количество предметов в стаке
                    {
                        slot.AddItem(newItem); // Используем метод для добавления предмета
                        return true; // Предмет успешно добавлен
                    }
                    else
                    {
                        Debug.Log("Превышено максимальное количество предметов в стаке!");
                        return false; // Предмет не добавлен из-за превышения стака
                    }
                }
                else if (!slot.IsOccupied())
                {
                    slot.AddItem(newItem); // Используем метод для добавления предмета
                    return true; // Предмет успешно добавлен
                }
            }
        }

        // Если достигли этой точки, значит все слоты заняты
        Debug.Log("Инвентарь полон!");
        return false; // Инвентарь полон, предмет не добавлен
    }

    private void ClearSlot(Transform slot)
    {
        InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();
        if (inventorySlot != null)
        {
            inventorySlot.ClearSlot();
        }
        else
        {
            Debug.LogWarning("Slot does not have an InventorySlot component: " + slot.name);
        }
    }
}
