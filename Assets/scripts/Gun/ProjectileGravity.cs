using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ProjectileGravity : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform planet;
    [SerializeField] float gravity;
    [SerializeField] GameObject explosion;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        var gravityVector = transform.position - planet.position;
        rb.velocity += gravityVector.normalized * gravity * Time.deltaTime;
        Debug.DrawRay(transform.position, gravityVector.normalized * (-20), Color.yellow);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var explosionInst = Instantiate(explosion, transform.position, transform.rotation);
        Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
    }
}
