using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platano : MonoBehaviour
{
    public int Value = 1; // El valor de la moneda
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            gameManager.SumarPuntos(Value);

            Destroy(this.gameObject);
        }
    }
}
