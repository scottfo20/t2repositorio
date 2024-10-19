using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUB : MonoBehaviour
{
        public GameManager gameManager;
        public TextMeshProUGUI puntos;
        void Update()
        {
        

    if (puntos != null && gameManager != null)
    {
        puntos.text = gameManager.PuntosTotales.ToString();
    }
        }

}
