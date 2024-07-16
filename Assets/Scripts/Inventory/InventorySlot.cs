using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image itemIcon; // Иконка предмета
    public TextMeshProUGUI itemName; // Название предмета
    public TextMeshProUGUI itemCount; // Количество предметов в стаке
    public Button removeButton; // Кнопка для удаления предмета из слота

    private ItemData currentItemData; // Данные о текущем предмете в слоте
    private int currentStackCount; // Текущее количество предметов в стаке
    private bool isOccupied; // Флаг, указывающий, занят ли слот

    public ItemData CurrentItemData { get { return currentItemData; } }
    public int CurrentStackCount { get { return currentStackCount; } }

    void Start()
    {
        ClearSlot();
        removeButton.onClick.AddListener(RemoveItem);
    }

    public void AddItem(Item newItem)
    {
        if (currentItemData != null && newItem.itemData.itemName == currentItemData.itemName)
        {
            // Если текущий предмет в слоту и новый предмет имеют одинаковые имена,
            // то увеличиваем количество в стаке до максимального размера стака
            if (currentStackCount < newItem.itemData.stackSize)
            {
                currentStackCount++;
                UpdateItemCountDisplay(); // Используем метод для обновления отображения
            }
            else
            {
                Debug.Log("Превышено максимальное количество предметов в стаке!");
            }
        }
        else
        {
            currentItemData = newItem.itemData; // Получаем данные о предмете из ItemData
            currentStackCount = 1; // Начинаем новый стак с одного предмета
            UpdateItemDisplay(); // Обновляем отображение предмета
        }

        isOccupied = true; // Устанавливаем слот как занятый
    }

    private void UpdateItemDisplay()
    {
        itemIcon.sprite = currentItemData.icon;
        itemName.text = currentItemData.itemName;
        itemIcon.enabled = true;
        itemName.enabled = true;
        removeButton.gameObject.SetActive(true);

        // Отображаем количество предметов, если их больше одного в стаке
        if (currentStackCount > 1)
        {
            itemCount.text = currentStackCount.ToString();
            itemCount.enabled = true;
        }
        else
        {
            itemCount.text = "";
            itemCount.enabled = false;
        }
    }

    public void UpdateItemCountDisplay() // Публичный метод для обновления количества предметов
    {
        // Отображаем количество предметов, если их больше одного в стаке
        if (currentStackCount > 1)
        {
            itemCount.text = currentStackCount.ToString();
            itemCount.enabled = true;
        }
        else
        {
            itemCount.text = "";
            itemCount.enabled = false;
        }
    }

    public void ClearSlot()
    {
        currentItemData = null;
        currentStackCount = 0;
        itemIcon.sprite = null;
        itemName.text = "";
        itemIcon.enabled = false;
        itemName.enabled = false;
        itemCount.text = "";
        itemCount.enabled = false;
        removeButton.gameObject.SetActive(false);
        isOccupied = false; // Освобождаем слот
    }

    public bool IsOccupied()
    {
        return isOccupied;
    }

    public void RemoveItem()
    {
        ClearSlot();
    }
}
