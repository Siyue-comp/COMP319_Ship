using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Instantiate an explosion and posistion it
        Instantiate(explosion, this.transform.position, this.transform.rotation);

        Destroy(other.gameObject); //Laser
        Destroy(this.gameObject); //Astroid
    }
}
