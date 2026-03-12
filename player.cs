using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    // Player Object To Chase
    public GameObject Player;

    // Object to be duplicated/spawned
    public GameObject Projectile;

    public TextMeshProUGUI pointsText;

    public float moveSpeed = 5f; 

    void Update()
    {
        // Average player movement
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical"); 

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);


        // Get mouse for aim
        Mouse mouse = Mouse.current;

        // Shoot bullets and work on upgrades
        if(mouse.leftButton.wasPressedThisFrame)
        {
            // Make a copy of projectile object
            GameObject copy = Instantiate(Projectile, Player.transform.position, Player.transform.rotation);
            copy.transform.LookAt(Player.transform.position);

            copy.transform.position += transform.forward * Time.deltaTime * moveSpeed;

            // Set size of projectile object from Variable component "size" in player object
            float size = System.Convert.ToSingle(Variables.Object(Player).Get("size"));
            copy.transform.localScale = new Vector3(size, size, size);

            // Add script forwardBoom responsible for projectile movement and detonation to projectile
            copy.AddComponent<forwardBoom>();
        }
        
        // Update player points
        pointsText.text =  ((int)Variables.Object(Player).Get("points")).ToString();
    }


}

