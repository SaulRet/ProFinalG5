using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float damage = 10.0F;

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
            controller.TakeDamage(damage, contactPoint);
            }
        }
    }
}
