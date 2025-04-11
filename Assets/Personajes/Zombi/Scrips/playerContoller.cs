using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerContoller : MonoBehaviour
{
    public float speed = 5f;
    public float fuerzaSalto = 7f;
    private Rigidbody2D rb;
    private bool mirandoDerecha = true;

    public Transform verificadorSuelo;
    public float radioSuelo = 0.2f;
    public LayerMask capaSuelo;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Conectamos el Animator
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        // Actualiza el parámetro Velocidad para controlar la animación
        animator.SetFloat("Velocidad", Mathf.Abs(moveX));

        // Salto
        bool enSuelo = Physics2D.OverlapCircle(verificadorSuelo.position, radioSuelo, capaSuelo);
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }

        // Girar sprite
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
        escala.x *= -1;
        transform.localScale = escala;
    }

    void OnDrawGizmosSelected()
    {
        if (verificadorSuelo != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(verificadorSuelo.position, radioSuelo);
        }
    }
}
