// Manages Player Behaviour
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    // Player Object
    public GameObject Player;

    // Object to be duplicated/spawned
    public GameObject Projectile;

    public float moveSpeed = 5f; 

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical"); 


        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);



        Mouse mouse = Mouse.current;

        // Firing Mechanics
        if(mouse.leftButton.wasPressedThisFrame)
        {
            GameObject copy = Instantiate(Projectile, Player.transform.position, Player.transform.rotation);
            copy.transform.LookAt(Player.transform.position);

            copy.transform.position += transform.forward * Time.deltaTime * moveSpeed;
            copy.AddComponent<forwardBoom>();
        }
    }


}


