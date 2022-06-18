using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float moveSpeed = 8.0f;
    public float topBound = 30.0f;
    public float sidebound = 13.0f;

    public Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    
    {
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed);
        if(transform.position.x > topBound)
        {
            Destroy(gameObject);
        }

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Damage();
        }

    }
    public void Damage()
    {
        Destroy(gameObject);
    }




}
