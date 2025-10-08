using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down

        Vector2 movement = new Vector2(moveX, moveY).normalized;
        transform.Translate(movement * speed * Time.deltaTime);
    }
}

