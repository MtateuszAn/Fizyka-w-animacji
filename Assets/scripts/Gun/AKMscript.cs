using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKMscript : MonoBehaviour
{
    [SerializeField] GameObject Projectile;
    [SerializeField] Transform pointOfFire;
    [SerializeField] float projectileSpeed;

    AudioSource fireSound;

    //muzzle Flash
    [SerializeField] GameObject muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        fireSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject flash = Instantiate(muzzleFlash, muzzleFlash.transform.position,muzzleFlash.transform.rotation, gameObject.transform);
        flash.gameObject.SetActive(true);
        Destroy(flash, 0.1f);

        fireSound.Play();
        GameObject bullet = Instantiate(Projectile, pointOfFire.transform.position, pointOfFire.transform.rotation);
        bullet.SetActive(true);
        if (bullet.TryGetComponent<Rigidbody>(out Rigidbody bulletrb))
            bulletrb.velocity = bullet.transform.forward * projectileSpeed;
    }
}
