using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlataformaMortal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Obt?n el componente HealthController del jugador y llama al m?todo HandlePlayerDeath
            HealthController playerHealth = other.GetComponent<HealthController>();
            if (playerHealth != null)
            {
                playerHealth.HandlePlayerDeath();
                // Puedes agregar aqu? la l?gica para mostrar el men? de Game Over
                MostrarMenuGameOver();
            }
        }
    }
    private void MostrarMenuGameOver()
    {
        // Busca el objeto con el script MenuGameOver y activa el men? Game Over
        MenuGameOver menuGameOver = FindObjectOfType<MenuGameOver>();
        if (menuGameOver != null)
        {
            menuGameOver.ActivarMenu(null, null);
        }
    }
}