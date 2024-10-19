using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    public int damage = 1; // Cantidad de daño que la trampa causa al jugador

    // Detectar cuando el jugador colisiona con la trampa
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que colisiona es el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            // Acceder al script de salud del jugador y reducir su salud
            Player playerHealth = other.GetComponent<Player>();
            
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Aplicar daño al jugador
            }
        }
    }
}
