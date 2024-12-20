using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Reference to the ball GameObject
    public GameObject ball;

    // Boolean flag to check if the game is over
    public bool gameOver;

    // Offset distance between the camera and the ball
    Vector3 offset;

    // Rate at which the camera follows the ball
    public float lerpRate;

    // Start is called before the first frame update
    // This method initializes the necessary components
    void Start()
    {
        // Calculate and store the offset value by getting the difference
        // between the ball's position and camera's position
        offset = ball.transform.position - transform.position;

        // Set the gameOver flag to false initially
        gameOver = false;
    }

    // Update is called once per frame
    // This method updates the camera position if the game is not over
    void Update()
    {
        // Check if the game is not over
        if (gameOver == false)
        {
            // Call the Follow method to update the camera's position
            Follow();
        }
    }

    // This method smoothly follows the ball
    void Follow()
    {
        // Get the current position of the camera
        Vector3 pos = transform.position;

        // Calculate the target position of the camera by subtracting the offset from the ball's position
        Vector3 targetPos = ball.transform.position - offset;

        // Interpolate (lerp) the camera's position towards the target position
        // The interpolation rate is determined by lerpRate and Time.deltaTime
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);

        // Update the camera's position to the newly calculated position
        transform.position = pos;
    }
}
