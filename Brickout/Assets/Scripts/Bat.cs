using UnityEngine;

public class Bat : MonoBehaviour // Class for the bat object
{
    public KeyCode moveLeftKey = KeyCode.LeftArrow; // Gets the movement key for the left direction
    public KeyCode moveRightKey = KeyCode.RightArrow; // Gets the movement key for the right direction
    bool canMoveLeft = true;
    bool canMoveRight = true;
    public float speed = 0.3f;
    float direction = 0.0f;

    void Update() // Method to enable the bat to move when the left or right arrow keys are pressed
    {
        bool isLeftPressed = Input.GetKey(moveLeftKey); // Gets a boolean value stating whether or not the left arrow key is held
        bool isRightPressed = Input.GetKey(moveRightKey); // Gets a boolean value stating whether or not the right arrow key is held

        if (isLeftPressed && canMoveLeft) // If statement to allow the bat to move left when it has the space to and the left arrow key is held
        {
            direction = -1.0f;
        }
        else if (isRightPressed && canMoveRight) // Else if to allow the bat to move right when it has the space to and the right arrow key is held
        {
            direction = 1.0f;
        }
        else
        {
            direction = 0.0f; // Else to have the bat remain stationary when no key is held or it is unable to move in a direction
        }
    }

    void FixedUpdate() // Method that moves the bat in accordance to the result of the previous method
    {
        Vector3 position = transform.localPosition; // Gets the position of the bat
        position.x += speed * direction; // Updates the direction of the bat
        transform.localPosition = position; // Updates the position of the bat
    }

    private void OnCollisionEnter2D(Collision2D other) // Method that stops the bat from moving beyond the left and right walls
    {
        switch (other.gameObject.name) // Switch statement to identify which wall the bat is colliding with
        {
            case "Left Wall":
                canMoveLeft = false; // Boolean set to false in order to stop the bat from moving further left
                break;

            case "Right Wall":
                canMoveRight = false; // Boolean set to false in order to stop the bat from moving further right
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D other) // Method that allows the bat to move left or right again after collision with a wall
    {
        switch (other.gameObject.name) // Switch statement to identify which wall is no longer colliding with the bat
        {
            case "Left Wall":
                canMoveLeft = true; // Sets boolean to true to allow the bat to move left again
                break;

            case "Right Wall":
                canMoveRight = true; // Sets boolean to true to allow the bat to move right again
                break;
        }
    }
}
