using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    private GameObject Player;
    public float speed = 5.1f;
    public GameObject GhostPrefab;
    private GameObject SpawnPoint;
    private bool Slowed = false;
    private void Start()
    {   
        GhostPrefab.name = "Ghost"; // This just makes it so the ghosts arent Ghost(Clone)
        Player = GameObject.FindWithTag("Player");  //Detects the player tag on the field 
        speed = 5.1f;                               //(normally there would be a check if null first but there will always be a player on the field)
        SpawnPoint = GameObject.FindWithTag("SpawnGhost");
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        //^ Makes ghost move^       ^Dictates that it should move towards ^Player which was located via tag, the rest how fast to move
    }

    // ALL BELOW WILL EVENTUALLY BE CHANGED TO EVENTS THIS IS A TEST
    // ALL BELOW WILL EVENTUALLY BE CHANGED TO EVENTS THIS IS A TEST
    // ALL BELOW WILL EVENTUALLY BE CHANGED TO EVENTS THIS IS A TEST

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Spawn(); // If collided with player, activate "Spawn"
        }               
    }
   
    private void Spawn()
    {
        GameObject Ghost = Instantiate(GhostPrefab) as GameObject; // Spawns a new ghost
        Ghost.transform.position = SpawnPoint.transform.position; // Moves it to spawn position
        Destroy(gameObject); // Destroys original Ghost, this has to be done last otherwise it won't spawn a new ghost
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Arcade")&& Slowed != true)
        {
            Debug.Log("Slowed");
            Slowed = true; // Slows down once, otherwise it continuesly applies Slowed
            speed = 2.5f; // If in an arcade collider slow down
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Slowed = false; // sets Slowed to false upon exiting any arcade collider
                        // so that it can reapply slowed if still in an arcade
                        // collider that isn't the original one it left
        speed = 5.1f; // Speeds back up once exiting any arcade collider
    }
}
