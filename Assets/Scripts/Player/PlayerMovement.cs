using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveDirection;
    public Joystick joystick; // Ссылка на джойстик

    void Update()
    {
        ProcessInputs();
        Move();
    }

    void ProcessInputs()
    {
        float moveX = joystick.Horizontal; // Используем данные джойстика
        float moveY = joystick.Vertical;
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}