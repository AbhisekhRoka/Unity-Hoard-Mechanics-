using UnityEngine;
using System.Collections; 
using Unity.VisualScripting;

// Script responsible for changing size of projectile
public class SizeManager : MonoBehaviour
{

    GameObject playerObject;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        // print for debug
        print((int)Variables.Object(playerObject).Get("points") > 10);
        print((int)Variables.Object(playerObject).Get("points"));

        // if player has 10 points decrease points by 10 and add 0.5 to projectile size
        if((int)Variables.Object(playerObject).Get("points") >= 10){
            Variables.Object(playerObject).Set("points", (int)Variables.Object(playerObject).Get("points") - 10);
            Variables.Object(playerObject).Set("size", (float)Variables.Object(playerObject).Get("size") + 0.5f);
        }
    }
}
