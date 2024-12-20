using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    public GameObject particle_effect;

    [SerializeField]
    float speed;
    [SerializeField]
    float fallThreshold = -5f; // Set this value to the height at which the ball is considered to have fallen off
    bool started;
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (started == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
                GameManager.instance.StartGame();
            }

        }

        if (Physics.Raycast(transform.position, Vector3.down, 1f) == false)
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            GameManager.instance.GameOver(); 
        }

        if (Input.GetMouseButtonDown(0) && gameOver == false)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if (gameOver == true)
        {
            return;
        }

        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "diamond")
        {
            Destroy(col.gameObject);
            GameObject particle = Instantiate(particle_effect, col.gameObject.transform.position, Quaternion.identity);
            Destroy(particle, 2f);
            
        }
    }
}
