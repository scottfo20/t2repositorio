using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importar para manejar la carga de escenas
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private float dirx = 0f;
    public int maxHealth = 3; // Número máximo de vidas
    private int currentHealth;

    public float speed = 7f; // Velocidad del jugador
    public float jumpForce = 8f; // Fuerza de salto

    public TextMeshProUGUI vidasText; // Referencia al componente TextMeshProUGUI para mostrar las vidas en pantalla

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth; // Iniciar con la cantidad máxima de vidas

        UpdateVidasText(); // Actualizar el texto de vidas al inicio

        // Cargar la posición si está disponible
        if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY"))
        {
            float savedX = PlayerPrefs.GetFloat("PlayerX");
            float savedY = PlayerPrefs.GetFloat("PlayerY");
            transform.position = new Vector2(savedX, savedY);
            Debug.Log("Posición cargada: (" + savedX + ", " + savedY + ")");
        }
    }

    void Update()
    {
        // Movimiento horizontal
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * speed, rb.velocity.y);

        // Saltar sin verificar si está en el suelo
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Guardar posición con la tecla "G"
        if (Input.GetKeyDown(KeyCode.G))
        {
            SavePosition();
        }

        // Cargar posición con la tecla "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            LoadPosition();
        }

        UpdateAnimationUpdate();
        FlipSprite();
    }

    // Control de animación
    private void UpdateAnimationUpdate()
    {
        if (dirx > 0f || dirx < 0f)
        {
            anim.SetBool("Runni", true);
        }
        else
        {
            anim.SetBool("Runni", false);
        }
    }

    // Voltear el sprite dependiendo de la dirección en la que se mueve el jugador
    private void FlipSprite()
    {
        if (dirx > 0)
        {
            spriteRenderer.flipX = false; // Mover hacia la derecha
        }
        else if (dirx < 0)
        {
            spriteRenderer.flipX = true; // Mover hacia la izquierda
        }
    }

    // Método para recibir daño
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Salud del jugador: " + currentHealth);

        UpdateVidasText(); // Actualizar el texto de vidas cuando el jugador reciba daño

        if (currentHealth <= 0)
        {
            Die(); // Llamar al método Die si las vidas llegan a 0
        }
    }

    // Método para manejar la muerte del jugador
    private void Die()
    {
        Debug.Log("El jugador ha muerto.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar el juego cargando la misma escena
    }

    // Método para actualizar el texto de vidas en pantalla
    private void UpdateVidasText()
    {
        vidasText.text = "Vidas: " + currentHealth; // Actualiza el texto mostrando el número de vidas restantes
    }

    // Guardar la posición del jugador
    private void SavePosition()
    {
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.Save();
        Debug.Log("Posición guardada: (" + transform.position.x + ", " + transform.position.y + ")");
    }

    // Cargar la posición del jugador
    private void LoadPosition()
    {
        if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY"))
        {
            float savedX = PlayerPrefs.GetFloat("PlayerX");
            float savedY = PlayerPrefs.GetFloat("PlayerY");
            transform.position = new Vector2(savedX, savedY);
            Debug.Log("Posición cargada: (" + savedX + ", " + savedY + ")");
        }
        else
        {
            Debug.Log("No se ha guardado ninguna posición.");
        }
    }
}
