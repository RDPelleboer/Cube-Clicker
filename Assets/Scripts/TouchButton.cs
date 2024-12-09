using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour
{
    private Collider2D buttonCollider;
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer

    // Define colors for touch states
    public Color touchBeganColour = Color.green; // Color when touch begins
    public Color touchEndedColour = Color.white; // Color when touch ends

    // Track if the button is currently pressed
    private bool isPressed = false;

    private PointManager pointManager;

    void Start()
    {
        // Get the collider and sprite renderer attached to this GameObject
        buttonCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        pointManager = FindObjectOfType<PointManager>();
    }

    void Update()
    {
        // Check if there are any touches
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                // Check the phase of the touch
                if (touch.phase == TouchPhase.Began)
                {
                    // Check if the touch position is within the button collider
                    if (buttonCollider != null && buttonCollider.OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position)))
                    {
                        // Handle touch began event
                        OnTouchBegan();
                    }
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    // Check if the touch position is within the button collider
                    if (buttonCollider != null && buttonCollider.OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position)))
                    {
                        // Handle touch ended event
                        OnTouchEnded();
                    }
                }
            }
        }
    }

    void OnTouchBegan()
    {
        if (!isPressed) // Check if the button is already pressed
        {
            isPressed = true; // Set pressed state
            if (spriteRenderer.color == Color.red)
            {
                pointManager.UpdateScore(1);
            }
            else
            {
                Time.timeScale = 0f;
                pointManager.EndMenu();
            }
            spriteRenderer.color = touchBeganColour; // Change the color when touched
            //Debug.Log("Touch began on button: " + gameObject.name); // Optional debug log
            // Add your logic for touch input here (e.g., jumping, shooting, etc.)
        }
    }

    void OnTouchEnded()
    {
        isPressed = false; // Reset pressed state
        spriteRenderer.color = touchEndedColour; // Change the color back when touch ends
        //.Log("Touch ended on button: " + gameObject.name); // Optional debug log
        // Add your logic for when the touch ends
    }
}
