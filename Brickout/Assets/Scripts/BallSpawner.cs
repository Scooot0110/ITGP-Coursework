using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour // Class that creates copies of the ball object
{
    public Ball ballTemplate; // Sets up a template ball for the spawner to create clones
    public int totalBalls = 3; // Sets the total amount of balls given to the player
    public Text balls;
    public Text gameOver;
    int lives = 3; // Sets the amount of lives the player has

    private void Start()
    {
        SpawnBall(ballTemplate); // Spawns the first ball
    }

    void SpawnBall(Ball template) // Method to spawn new balls
    {
        Ball newBall = Instantiate(template); // Instantiates a new ball object

        newBall.transform.position = transform.position; // Sets the position of the new ball

        int angle = Random.Range(30, 160); // Generates a random angle in degrees
        newBall.SetDirection(angle); // Calls the SetDirection method to apply the angle to the ball
        newBall.gameObject.SetActive(true); // Activates the ball in unity
    }

    public void DespawnBall(Ball ballToDespawn) // Method that despawns balls
    {
        Destroy(ballToDespawn.gameObject); // Destroys the current ball

        lives--; // Reduces the player's lives when a ball is lost

        if(lives > 0)
        {
            SpawnBall(ballTemplate); // Spawns a new ball
        }
        if(lives == 0)
        {
            gameOver.gameObject.SetActive(true); // Displays the game over message
        }
    }

    private void Update()
    {
        balls.text = "Balls Left: " + lives; // Updates the number of balls the player has left
    }
}