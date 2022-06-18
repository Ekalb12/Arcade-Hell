using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // list of variables 
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 20.0f;
    public float verticalInput;
    public float yRange = 13.0f;
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // keep player inbounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.y < -yRange)
        {
            transform.position = new Vector3( transform.position.x,-yRange, transform.position.z);
        }
        if(transform.position.y >yRange)
        {
            transform.position = new Vector3( transform.position.x,yRange, transform.position.z);
        }
        // movement of player right to left and up and down
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
        verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector2.up* Time.deltaTime * speed * verticalInput);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBody"))
        {
            Damage();
        }

    }
    public void Damage()
    {

            health--;
        Debug.Log("Health left = " + health);
        if (health > 0)
        {
            GameEvents.OnDamageTaken?.Invoke(health);

        }

        if (health == 0)
        {
            GameEvents.OnDamageTaken?.Invoke(health);
            Debug.Log("GameLost");
            GameEvents.OnGameOver?.Invoke();

        }

    }
}
