// Manages Spawner Behaviour
using UnityEngine;
using System.Collections; 

public class Spawn : MonoBehaviour
{
    // Object to be duplicated/spawned
    public GameObject SpawnObject; 

    // Spawner object
    public GameObject Spawner;

    // Level / Wave number
    public int wave;

    void Start()
    {    
        // Spawn on a timer 3 sec
        StartCoroutine(SpawnCoroutine()); 
    }

    IEnumerator SpawnCoroutine()
    {
        // Spawn rate : wave * 2
        for(int i = 0; i < wave * 2; i++){
            // Keep track on when spawned
            Debug.Log("I SUMMON THEE " + Time.time); 
            GameObject copy = Instantiate(SpawnObject, Spawner.transform.position, Spawner.transform.rotation);
            // 6 sec wait time
            yield return new WaitForSeconds(3);
        }
    }
}

