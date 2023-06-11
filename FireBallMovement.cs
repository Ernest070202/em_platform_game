using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireBallMovement : MonoBehaviour
{
    [SerializeField] float FireballVelocity = 15f;


    void Update()
    { 
        transform.position += FireballVelocity * transform.right;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Trap"))
            Destroy(gameObject);
    }
}
