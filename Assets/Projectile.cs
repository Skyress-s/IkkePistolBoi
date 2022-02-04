using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;

    public bool bHit = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = rb.velocity.normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        bHit = true;

        
        Debug.Log("DID HIT SOMETHING!");
        //Destroy(gameObject);
    }

}
