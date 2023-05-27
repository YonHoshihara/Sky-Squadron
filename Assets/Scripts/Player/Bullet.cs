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
        rb.velocity = new Vector3(0,0,1) * speedModifier;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
