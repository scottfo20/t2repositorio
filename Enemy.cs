using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float speed = 2f; // Velocidad del enemigo
    private float leftBoundary = 30f; // Límite izquierdo
    private float rightBoundary = 39f; // Límite derecho
    private bool movingRight = true; // Indica la dirección de movimiento
    private SpriteRenderer spriteRenderer; // Componente SpriteRenderer

    public Player player; // Referencia al script del jugador para reducir vida

    private void Start()
    {
        // Obtener el componente SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Encuentra al jugador automáticamente si no lo has asignado en el Inspector
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
    }

    void Update()
    {
        // Movimiento del enemigo
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); // Mover a la derecha
            spriteRenderer.flipX = false; // Voltear el sprite a la derecha

            // Verificar si ha alcanzado el límite derecho
            if (transform.position.x >= rightBoundary)
            {
                movingRight = false; // Cambiar dirección
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime); // Mover a la izquierda
            spriteRenderer.flipX = true; // Voltear el sprite a la izquierda

            // Verificar si ha alcanzado el límite izquierdo
            if (transform.position.x <= leftBoundary)
            {
                movingRight = true; // Cambiar dirección
            }
        }
    }

    // Cuando el enemigo colisione con el jugador, le quitará una vida
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el enemigo ha colisionado con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // El jugador pierde una vida
            player.TakeDamage(1);
            // Destruir el enemigo después de que toca al jugador
          //  Destroy(gameObject); 
        }
    }

    // El enemigo se destruye cuando sale de la pantalla
    //private void OnBecameInvisible()
   // {
    //    Destroy(gameObject); // Eliminar el enemigo al salir de la pantalla
    //}
}
