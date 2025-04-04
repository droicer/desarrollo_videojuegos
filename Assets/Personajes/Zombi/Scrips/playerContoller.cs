using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerContoller : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private bool mirandoDerecha = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        // Verifica si hay movimiento en X
        if (moveX > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (moveX < 0 && mirandoDerecha)
        {
            Girar();
        }
    }

    void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1; // invierte la dirección del sprite
        transform.localScale = escala;
    }
}
