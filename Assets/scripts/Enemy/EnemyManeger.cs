using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManeger : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] Transform planet;
    [SerializeField] float distanceToExplode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(planet.position, transform.position ) >= distanceToExplode)
        {
            var explosionInst = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    
}
