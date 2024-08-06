using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Velocity = 20;
    private Rigidbody rigidbodyPlayer;
    
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rigidbodyPlayer.MovePosition(rigidbodyPlayer.position + transform.forward * Velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider Collison_object)
    {
        if (Collison_object.tag == "Inimigo")
        {
            Destroy(Collison_object.gameObject);
        }
        Destroy(gameObject);
    }
}