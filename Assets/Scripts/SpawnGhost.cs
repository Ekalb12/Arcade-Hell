using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    public GameObject GhostPrefab;
    public Transform SpawnPoint; // place it spawns
    private bool Spawned = false; // sets spawned to false
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player")&& Spawned != true) // && Spawned != true means it only works if "Spawned" = false
        {
            Spawn();
        }
    }
    private void Spawn()
    {
        GameObject Ghost = Instantiate(GhostPrefab) as GameObject; // Declares the prefab as gameobject
        Ghost.transform.position = SpawnPoint.transform.position; // spawns it at the spawn point
        GhostPrefab.name = "Ghost"; // makes it not have (Clone) in the name (Not needed just my OCD)
        Spawned = true; // because its on trigger it can have issues, this makes it only able to spawn one
        Destroy(gameObject); // deletes the trigger as it is no longer needed
    }
}
