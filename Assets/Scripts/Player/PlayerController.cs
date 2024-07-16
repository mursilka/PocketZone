using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float interactionRadius = 1.5f; // Радиус взаимодействия игрока с предметами
    public Inventory inventory; // Ссылка на инвентарь игрока

    private void Update()
    {
        
        CheckForItemsInRange(); // Проверяем, есть ли предметы в радиусе действия
        
    }

    private void CheckForItemsInRange()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius);

        foreach (Collider2D collider in colliders)
        {
            Item item = collider.GetComponent<Item>();
            if (item != null && item.itemData != null) // Проверяем, что у предмета есть данные
            {
                // Взаимодействуем с предметом
                Debug.Log("Player interacted with item: " + item.itemData.itemName);

                // Передаем сам объект предмета в инвентарь
                bool added = inventory.AddItem(item);

                // Уничтожаем объект предмета на сцене, если добавление в инвентарь успешно
                if (added)
                {
                    Destroy(item.gameObject);
                }

                // Прерываем цикл после первого найденного предмета
                return;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Рисуем круг в редакторе, чтобы видеть радиус взаимодействия
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}