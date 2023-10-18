using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ProjectileGravity : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform planet;
    [SerializeField] float gravity;

    // Update is called once per frame
    void Update()
    {
        var gravityVector = transform.position - planet.position;
        rb.velocity += gravityVector.normalized * gravity * Time.deltaTime;
        Debug.DrawRay(transform.position, gravityVector.normalized * (-20), Color.yellow);
    }
}
