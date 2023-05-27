using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  
    [SerializeField]
    private float speedModifier;

    [SerializeField]
    private Rigidbody rb;

    private void Start()
    {
        rb.velocity = Vector3.up * speedModifier;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
