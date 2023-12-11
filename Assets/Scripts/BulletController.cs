using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float lifeTime = 3.0F;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtén el componente HealthController del jugador y llama al método HandlePlayerDeath
            HealthController playerHealth = collision.gameObject.GetComponent<HealthController>();
            if (playerHealth != null)
            {
                playerHealth.HandlePlayerDeath();
                // Puedes agregar aquí la lógica para mostrar el menú de Game Over
                MostrarMenuGameOver();
            }
        }
        Destroy(gameObject);
    }

    private void MostrarMenuGameOver()
    {
        // Busca el objeto con el script MenuGameOver y activa el menú Game Over
        MenuGameOver menuGameOver = FindObjectOfType<MenuGameOver>();
        if (menuGameOver != null)
        {
            menuGameOver.ActivarMenu(null, null);
        }
    }
}
