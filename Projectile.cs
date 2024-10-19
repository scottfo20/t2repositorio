using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el proyectil colisiona con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Puedes hacer que el jugador reciba daño, pierda una vida, etc.
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(1); // Método para hacer que el jugador reciba daño
            }

            // Destruir el proyectil al colisionar con el jugador
            Destroy(gameObject);
        }
        else
        {
            // Destruir el proyectil cuando colisione con cualquier otro objeto
            Destroy(gameObject);
        }
    }
}
