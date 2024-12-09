using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    private PointManager pointManager;
    private InterstitialAdExample interstitialAd;

    public AudioClip[] audioClips; // List of AudioClips to choose from
    public float interval = 2.0f; // Interval in seconds
    private AudioSource audioSource; // AudioSource for playing sounds

    private float nextPlayTime;
    int counter;

    public GameObject[] buttons;
    private SpriteRenderer spriteRenderer;
    public Color activeColour = Color.red; 
    public Color midColour = Color.yellow; 
    public Color inactiveColour = Color.white;

    public int redSquaresTotal;
    public bool youLost = false;

    void Start()
    {
        pointManager = FindObjectOfType<PointManager>();
        interstitialAd = FindObjectOfType<InterstitialAdExample>();

        Time.timeScale = 1f;

        // Create an AudioSource component if one doesn't exist
        audioSource = gameObject.AddComponent<AudioSource>();

        // Initialize the next play time
        nextPlayTime = Time.time + interval;

        youLost = false;
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
            //Debug.Log(interval);

            nextPlayTime = Time.time + interval; // Reset the timer
        }

        if (redSquaresTotal >= 16)
        {
            pointManager.EndMenu();
            youLost = true;
        }
    }

    void PlayRandomSound()
    {
        if (youLost)
            return;

        // Choose a random AudioClip from the list
        int randomIndex = Random.Range(0, audioClips.Length);
        
        //Play audio clip
        audioSource.clip = audioClips[randomIndex];
        audioSource.Play();
        //Debug.Log("Play" + audioClips[randomIndex]);

        //Choose and change random button

        if (redSquaresTotal == 15)
        {
            randomIndex = 0;
        }
        
        if (redSquaresTotal < 16 && youLost == false) {
        if (randomIndex == 0)
        {
            int randomButton = Random.Range(0, buttons.Length);

            //Change button colour to active
            spriteRenderer = buttons[randomButton].GetComponent<SpriteRenderer>();

            while (spriteRenderer.color == Color.red)
            {
                randomButton = Random.Range(0, buttons.Length);
                spriteRenderer = buttons[randomButton].GetComponent<SpriteRenderer>();
                Debug.Log("changed button to new square");
            }
            spriteRenderer.color = activeColour;
            redSquaresTotal++;
            Debug.Log("total red squares is: " + redSquaresTotal);
        } else if (randomIndex == 1)
        {
            int randomButton1 = Random.Range(0, buttons.Length);
            int randomButton2 = Random.Range(0, buttons.Length);

            //Change button colour to active
            spriteRenderer = buttons[randomButton1].GetComponent<SpriteRenderer>();
            while (spriteRenderer.color == Color.red)
            {
                randomButton1 = Random.Range(0, buttons.Length);
                spriteRenderer = buttons[randomButton1].GetComponent<SpriteRenderer>();
                Debug.Log("changed button1 to new square");
            }
            spriteRenderer.color = activeColour;
            redSquaresTotal++;
            spriteRenderer = buttons[randomButton2].GetComponent<SpriteRenderer>();
            while (spriteRenderer.color == Color.red)
            {
                randomButton2 = Random.Range(0, buttons.Length);
                spriteRenderer = buttons[randomButton2].GetComponent<SpriteRenderer>();
                Debug.Log("changed button2 to new square");
            }
            spriteRenderer.color = activeColour;
            redSquaresTotal++;
            Debug.Log("total red squares is: " + redSquaresTotal);
        }
        }
    }
}
