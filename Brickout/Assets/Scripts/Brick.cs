using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public BrickSpawner spawner; // Declares a variable of the BrickSpawner class to allow this script to access the BrickSpawner script
    private void OnCollisionEnter2D(Collision2D other) // Method that runs when the brick collides with another object
    {
        if (other.gameObject.name == "Ball(Clone)")
        {
            spawner.DespawnBrick(this); // Destroys the brick if the ball collides with it
        }
    }
}
