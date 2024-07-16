using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData; // Данные предмета

    private void Reset()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider2D>();
        }
        collider.isTrigger = true;
        gameObject.layer = LayerMask.NameToLayer("Item"); // Назначаем слой "Item"
    }
}