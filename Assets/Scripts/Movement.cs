using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    private bool isMoving = true;
    private Coroutine movementCoroutine;

    private void Update()
    {
        if (isMoving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                StartMovement("up");
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                StartMovement("left");
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                StartMovement("down");
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                StartMovement("right");
            }
        }
    }

    private void StartMovement(string direction)
    {
        // Stop any existing movement coroutine
        if (movementCoroutine != null)
        {
            StopCoroutine(movementCoroutine);
        }

        StartCoroutine(AllowInputs());

        // Start a new movement coroutine
        movementCoroutine = StartCoroutine(MoveInDirection(direction));
    }

    private IEnumerator MoveInDirection(string direction)
    {
        while (true) // Keep moving until interrupted
        {
            Move(direction);
            yield return null; // Wait for the next frame
        }
    }

    private void Move(string direction)
    {
        Vector2 movement = Vector2.zero;

        switch (direction)
        {
            case "up":
                movement = Vector2.up;
                break;
            case "left":
                movement = Vector2.left;
                break;
            case "down":
                movement = Vector2.down;
                break;
            case "right":
                movement = Vector2.right;
                break;
        }

        transform.Translate(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BlueSquare") && gameObject.CompareTag("BlueSquare"))
        {
            // Stick together: make the other blue square a child of this one
            other.transform.SetParent(transform);
            Debug.Log("Blue squares stuck together");

            // Stop movement for both after sticking
            isMoving = false;

            if (movementCoroutine != null)
            {
                StopCoroutine(movementCoroutine);
            }
        }
        else
        {
            Debug.Log("Triggered with " + other.gameObject.name);
            isMoving = false; // Stop movement upon triggering another object

            if (movementCoroutine != null)
            {
                StopCoroutine(movementCoroutine);
            }
        }
    }

    IEnumerator AllowInputs()
    {
        yield return new WaitForSeconds(2);
        isMoving = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isMoving = true;
    }
}