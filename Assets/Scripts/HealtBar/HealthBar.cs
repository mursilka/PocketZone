using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthFill; // Ссылка на заполненную часть полоски здоровья
    private float maxHealth = 100f; // Максимальное значение здоровья по умолчанию
    private float currentHealth; // Текущее значение здоровья

    void Start()
    {
        // Устанавливаем начальное значение здоровья равным максимальному
        currentHealth = maxHealth;
        SetHealth(0); // Устанавливаем начальное значение здоровья на полоске
    }

    // Метод для установки значения здоровья
    public void SetHealth(float damage)
    {
        // Вычитаем урон из текущего здоровья
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ограничиваем значение здоровья

        // Вычисляем процент здоровья
        float fillAmount = currentHealth / maxHealth;
        // Устанавливаем fillAmount для заполненной части полоски здоровья
        healthFill.fillAmount = fillAmount;
    }

    // Метод для инициализации максимального здоровья
    public void InitializeHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        SetHealth(0); // Обновляем полосу здоровья с новым максимальным значением
    }
}