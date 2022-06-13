using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public Transform SpawnPoint;

    void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        GameObject Player = Instantiate(PlayerPrefab) as GameObject;
        Player.transform.position = SpawnPoint.transform.position;
        PlayerPrefab.name = "Player";
        Destroy(gameObject);
    }
}
