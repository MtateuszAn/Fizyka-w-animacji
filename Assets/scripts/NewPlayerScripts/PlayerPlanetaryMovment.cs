using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlanetaryMovment : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpForce = 2f;

    [SerializeField] Transform planet;
    [SerializeField] float autoOrientSpeed;
    [SerializeField] float projectileSpeed;
    Vector3 gravityVector;

    public Transform groundCeck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool wasGrounded;

    [SerializeField] GameObject Projectile;
    [SerializeField] Transform pointOfFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCeck.position, groundDistance, groundMask);
        gravityVector = transform.position - planet.position;
        if(isGrounded != wasGrounded && !wasGrounded)
        {
            velocity = velocity*0;
        }
        wasGrounded = isGrounded;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(!isGrounded)Gravity();

        Rotate();
        controller.Move(velocity * Time.deltaTime);

    }

    void Gravity()
    {
        velocity += gravityVector.normalized * gravity* Time.deltaTime;
        Debug.DrawRay(transform.position, gravityVector.normalized*(-20), Color.yellow);
    }

    void Rotate()
    {
        Quaternion orientationDirection = Quaternion.FromToRotation(-transform.up, -gravityVector) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, orientationDirection, Time.deltaTime * autoOrientSpeed);
    }

    void Jump()
    {
        velocity = gravityVector.normalized * jumpForce;
    }

    void Fire()
    {
        GameObject bullet = Instantiate(Projectile, pointOfFire.transform.position, pointOfFire.transform.rotation);
        if(bullet.TryGetComponent<Rigidbody>(out Rigidbody bulletrb))
            bulletrb.velocity = bullet.transform.forward * projectileSpeed;
    }
}
