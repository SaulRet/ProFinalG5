using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100.0f;
    private float currentHealth;
    
    

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // Aplicar da�o al enemigo
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Puedes agregar m�s l�gica aqu� si deseas realizar alguna acci�n espec�fica al eliminar al enemigo
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Vector2 contactPoint = other.GetContact(0).normal;

            if (contactPoint.y < -0.9F)
            {
                Character2DController.Instance.Rebound();
                Destroy(gameObject);
            }
            else
            {
                HealthController controller = other.collider.GetComponent<HealthController>();
                if (controller != null)
                {
                    float damage = 10.0f; // Ajusta este valor seg�n sea necesario
                    // Aplicar da�o al jugador
                    controller.TakeDamage(damage, contactPoint);

                    // Eliminar al enemigo despu�s de infligir da�o al jugador
                    TakeDamage(damage); // Puedes ajustar el da�o para que el enemigo se elimine inmediatamente
                }

            }
           
            }
        }
    }

