using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel; // Ссылка на панель инвентаря
    public Button toggleButton; // Ссылка на кнопку для открытия/скрытия инвентаря

    private bool isInventoryVisible = false; // Флаг, указывающий на видимость инвентаря

    void Start()
    {
        // Убедитесь, что панель инвентаря скрыта по умолчанию
        inventoryPanel.SetActive(isInventoryVisible);

        // Добавляем слушатель нажатия на кнопку
        toggleButton.onClick.AddListener(ToggleInventory);
    }

    void ToggleInventory()
    {
        // Переключаем видимость инвентаря
        isInventoryVisible = !isInventoryVisible;
        inventoryPanel.SetActive(isInventoryVisible);
    }
}