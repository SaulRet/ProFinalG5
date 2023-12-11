using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float health;

    [SerializeField]
    float maxHealth = 100.0F;

    [SerializeField]
    float loseControlTimeout = 1.25F;

    [SerializeField]
    Vector2 reboundVelocity;

    public event EventHandler MuerteJugador;

    Character2DController _characterController;
    HealthBarController _healthBarController;

    Rigidbody2D _rb;

    void Start()
    {
        health = maxHealth;

        _healthBarController = GetComponent<HealthBarController>();
        _healthBarController.Initialize(health);

        _characterController = Character2DController.Instance;

        if (_characterController == null)
        {
            Debug.LogError("Character2DController.Instance is null. Make sure it's properly set up in your scene.");
        }
        else
        {
            _rb = GetComponent<Rigidbody2D>();
        }
    }

    void Rebound(Vector2 contactPoint)
    {
        _rb.velocity = new Vector2(-reboundVelocity.x * contactPoint.x, reboundVelocity.y);
    }

    public void TakeDamage(float damage, Vector2 contactPoint)
    {
        health -= damage;
        if (health <= 0.0F)
        {
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            HandlePlayerDeath();  // Aseg�rate de llamar HandlePlayerDeath tambi�n aqu� si la salud llega a cero
        }

        _characterController.animator.SetTrigger("hit");
        _healthBarController.OnDamage.Invoke(damage);

        Rebound(contactPoint);
        StartCoroutine(LoseControl());
    }

    IEnumerator LoseControl()
    {
        _characterController._canMove = false;
        yield return new WaitForSeconds(loseControlTimeout);
        _characterController._canMove = true;
    }

    public void Heal(float value)
    {
        health += Mathf.Abs(value);
        _healthBarController.OnHeal.Invoke(value);
    }

    public void HandlePlayerDeath()
    {
        MuerteJugador?.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);
    }
}
