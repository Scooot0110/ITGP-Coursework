using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickSpawner : MonoBehaviour
{
    public Brick brickTemplate; // Sets up a brick template for the spawner to clone
    int level = 1; // Sets the current levels in the game
    public int totalLevels = 3; // Sets the max level in the game
    public int column = 10; // The amount of columns of bricks to be spawned
    public int row = 5; // The amount of rows of bricks to be spawned
    List<Brick> brickList = new List<Brick>(); // List to keep track of the bricks
    public Text currentLevel;
    public Text gameWon;

    private void Start()
    {
        currentLevel.text = "Level " + level; // Displays message containing the current level
        SpawnBrick(brickTemplate); // Spawns the first set of bricks
    }

    private void SpawnBrick(Brick template)
    {
        int posX = -6;
        int posY = 0;
        for (int countX = 0; countX < column; countX++)
        {
            for (int countY = 0; countY < row; countY++)
            {
                Brick newBrick = Instantiate(template, new Vector2(posX, posY), Quaternion.identity); // Instantiates the new brick object and places it in its position
                brickList.Add(newBrick); // Adds the new brick to the list
                newBrick.gameObject.SetActive(true); // Activates the new brick
                posY++;
            }
            posX += 3;
            posY = 0;
        }
    }

    public void DespawnBrick(Brick brickToDestroy)
    {
        Destroy(brickToDestroy.gameObject); // Destroys the brick that was hit by the ball

        brickList.Remove(brickToDestroy); // Removes the destroyed brick from the list
    }

    private void Update()
    {
        if (brickList.Count == 0 && level < totalLevels) // If statement to start the next level if all bricks have been destroyed and there are levels left
        {
            SpawnBrick(brickTemplate); // Spawns a new set of bricks
            level++;
            currentLevel.text = "Level " + level; // Updates the current level UI element
        }
        else if (brickList.Count == 0 && level == totalLevels) // else if to allow the you win message to appear when the player completes the game
        {
            gameWon.gameObject.SetActive(true); // Activates the Game Won object
        }
    }
}
