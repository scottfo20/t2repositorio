using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class Cup : MonoBehaviour
{
    // Método que se activa cuando el jugador entra en contacto con la copa
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que entró es el jugador
        if (other.CompareTag("Player"))
        {
                        other.transform.position = new Vector2(0f, 0f);

            Debug.Log("¡Juego terminado!"); // Mensaje en la consola

            // Aquí puedes mostrar una pantalla de "Juego terminado" o reiniciar el nivel
            // Si deseas reiniciar el nivel, puedes usar: 
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // Si deseas cargar una escena diferente (como una pantalla de fin de juego):
            //SceneManager.LoadScene("NombreDeLaEscenaDeFinDeJuego");
        }
    }
}
