using UnityEngine;
using System.Collections; 
using Unity.VisualScripting;


public class forwardBoom : MonoBehaviour
{

    GameObject playerObject;

    public bool des = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        print("boom " + playerObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 5;

        StartCoroutine(ExplodeSoon()); 
        
    
    }

    // Explode after 2 seconds
    IEnumerator ExplodeSoon()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    void  OnCollisionEnter (Collision collision) {
        // Print for debug
        print(collision.gameObject.tag);

        // if collision with Enemy, set points in Player Variables to +1 and destroy projectile as well as Enemy
        if (collision.gameObject.tag == "Enemy" ) {
            print ("MUAHAHHAA SHOT DOWN");
            collision.gameObject.SetActive(false);
            Variables.Object(playerObject).Set("points", (int)Variables.Object(playerObject).Get("points") + 1);
            Destroy(gameObject);
        }
        
    }

}
