using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour // Class for the ball object
{
    public BallSpawner ballSpawner; // Declares a variable of the BallSpawner class to allow this script to access the BallSpawner script
    public AudioSource audio; // Declares an AudioSource variable to allow this script to access the audio clip specified in unity
    float speed = 0.2f;
    float directionX = 0.5f;
    float directionY = 1.0f;

    private void FixedUpdate() // Method to move the ball
    {
        Vector3 position = transform.localPosition; // Gets the position of the ball
        position.x += speed * directionX; // Updates the direction of the ball on the x axis
        position.y += speed * directionY; // Updates the direction of the ball on the y axis
        transform.localPosition = position; // Updates the position of the ball
    }

    private void OnCollisionEnter2D(Collision2D other) // Method that runs when the ball collides with another object
    {
        switch (other.gameObject.name)
        {
            case "Left Wall":
            case "Right Wall":
                directionX = -directionX; // Inverts the horizontal direction
                break;

            case "Ceiling":
            case "Bat":
                directionY = -directionY; // Inverts the vertical direction
                break;

            case "Floor":
                ballSpawner.DespawnBall(this); // Destroy the ball
                break;

            case "Brick(Clone)":
                directionY = -directionY; // Inverts the vertical direction
                audio.Play();
                break;
        }
    }

    public void SetDirection(int angleInDegrees) // Method that sets the angle of the ball in degrees
    {
        float angleInRadians = angleInDegrees * Mathf.Deg2Rad;
        directionX = Mathf.Cos(angleInRadians);
        directionY = Mathf.Sin(angleInRadians);
    }
}