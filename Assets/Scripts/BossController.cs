using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BossController : MonoBehaviour

{
    public GameObject prefabBala;
    public Transform puntoDisparo;
    public float velocidadBala = 5f;
    [SerializeField]
    [Range(0.1F, 1.0F)]
    float firerate = 0.3F;
    float _fireTimer;

    void Update()
    {
        _fireTimer -= Time.deltaTime;
        if (_fireTimer <= 0.0F)
        {
            Shoot();
            _fireTimer = firerate;
        }
    }

    void Shoot()
    {
        // Instancia la bala desde el prefab en la posición del punto de disparo
        GameObject bala = Instantiate(prefabBala, puntoDisparo.position, puntoDisparo.rotation);

        // Accede al componente Rigidbody2D de la bala para aplicarle una velocidad
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        if (rbBala != null)
        {
            rbBala.velocity = puntoDisparo.right * velocidadBala;
        }
    }

}
