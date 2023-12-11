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

    void FixedUpdate() 
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy (gameObject);
    }
}
