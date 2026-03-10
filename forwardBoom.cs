// Manages Projectile Mechanics
using UnityEngine;
using System.Collections; 


public class forwardBoom : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        // Moves the projectile forward
        transform.position += transform.forward * Time.deltaTime * 5;
        // Gives the projectil e2 sec lifespan or when it hits something
        StartCoroutine(ExplodeSoon()); 
    }

    // Destroys the bullet in 2 secs or if it hits an "Enemy" tag
    IEnumerator ExplodeSoon()
    {
        yield return new WaitForSeconds(2);
        Explode();
        Destroy(gameObject);
    }


    // This is for whatever particle system you use for the explosion
    void Explode() {
        var exp = GetComponent<ParticleSystem>();
        exp.Play();
    }

    void  OnCollisionEnter (Collision collision) {
        print(collision.gameObject.tag); 
        
        if (collision.gameObject.tag == "Enemy" ) {
            print ("MUAHAHHAA SHOT DOWN");
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        
    }

}



