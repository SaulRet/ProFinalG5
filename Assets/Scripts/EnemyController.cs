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
        // Aplicar daño al enemigo
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Puedes agregar más lógica aquí si deseas realizar alguna acción específica al eliminar al enemigo
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
                    float damage = 10.0f; // Ajusta este valor según sea necesario
                    // Aplicar daño al jugador
                    controller.TakeDamage(damage, contactPoint);

                    // Eliminar al enemigo después de infligir daño al jugador
                    TakeDamage(damage); // Puedes ajustar el daño para que el enemigo se elimine inmediatamente
                }

            }
           
            }
        }
    }

