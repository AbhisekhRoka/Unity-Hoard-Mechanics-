using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject Player; # Set to player object
    public float speed = 0.5f; # Set to speed

    void Update()
    {
        # Rotate and Move towards player
        transform.LookAt(Player.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }
    void  OnCollisionEnter (Collision collision) {
        print("?");
        # Detect Collision with Player, change to destroy to health dmaage however you see fit
        if (collision.gameObject.tag == "Player" ) {
            print ("MUAHAHHAA GOTCHU");
        }
    }
}

