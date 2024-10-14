using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips; // List of AudioClips to choose from

    public float interval = 2.0f; // Interval in seconds

    private AudioSource audioSource; // AudioSource for playing sounds
    private float nextPlayTime;
    int counter;

    public GameObject[] buttons;
    private SpriteRenderer spriteRenderer;
    public Color activeColour = Color.red; // Color when touch begins
    public Color inactiveColour = Color.white; // Color when touch ends

    void Start()
    {
        Time.timeScale = 1f;

        // Create an AudioSource component if one doesn't exist
        audioSource = gameObject.AddComponent<AudioSource>();

        // Initialize the next play time
        nextPlayTime = Time.time + interval;
    }

    void Update()
    {
        // Check if it's time to play the sound
        if (Time.time >= nextPlayTime)
        {
            PlayRandomSound();
            counter++;
            
            if (counter == 10 && interval !> 0.2)
            {
                interval = interval - 0.1f;
                counter = 0;
            }
            Debug.Log(interval);

            nextPlayTime = Time.time + interval; // Reset the timer
        }
    }

    void PlayRandomSound()
    {
        // Choose a random AudioClip from the list
        int randomIndex = Random.Range(0, audioClips.Length);
        
        //Play audio clip
        audioSource.clip = audioClips[randomIndex];
        audioSource.Play();
        Debug.Log("Play" + audioClips[randomIndex]);

        //Choose and change random button
        if (randomIndex == 0)
        {
            int randomButton = Random.Range(0, buttons.Length);

            //Change button colour to active
            spriteRenderer = buttons[randomButton].GetComponent<SpriteRenderer>();
            spriteRenderer.color = activeColour;
        } else if (randomIndex == 1)
        {
            int randomButton1 = Random.Range(0, buttons.Length);
            int randomButton2 = Random.Range(0, buttons.Length);

            //Change button colour to active
            spriteRenderer = buttons[randomButton1].GetComponent<SpriteRenderer>();
            spriteRenderer.color = activeColour;
            spriteRenderer = buttons[randomButton2].GetComponent<SpriteRenderer>();
            spriteRenderer.color = activeColour;
        }
    }
}
