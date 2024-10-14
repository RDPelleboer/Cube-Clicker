//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[System.Serializable]
//public class AudioClipGroup
//{
//    public List<AudioClip> audioClips = new List<AudioClip>();
//}

//public class AudioManager : MonoBehaviour
//{
//    public AudioClip[] audioClips; // List of AudioClips to choose from
//    public List<AudioClipGroup> audioQueList = new List<AudioClipGroup>();

//    public float interval = 2.0f; // Interval in seconds

//    private AudioSource audioSource; // AudioSource for playing sounds
//    private float nextPlayTime;

//    private bool isPlaying = false;

//    public GameObject[] buttons;
//    private SpriteRenderer spriteRenderer;
//    public Color activeColour = Color.red; // Color when touch begins
//    public Color inactiveColour = Color.white; // Color when touch ends

//    int chosenClipID;

//    void Start()
//    {
//        // Create an AudioSource component if one doesn't exist
//        audioSource = gameObject.AddComponent<AudioSource>();

//        // Initialize the next play time
//        nextPlayTime = Time.time + interval;
//    }

//    void Update()
//    {
//        // Check if it's time to play the sound
//        if (Time.time >= nextPlayTime && !isPlaying)
//        {
//            PlayRandomSound();
//            nextPlayTime = Time.time + interval; // Reset the timer
//        }
//    }

//    void PlayRandomSound()
//    {
//        // Choose a random AudioClip from the list
//        int randomIndex = Random.Range(0, audioQueList.Count);
//        AudioClipGroup chosenGroup = audioQueList[randomIndex];
//        chosenClipID = randomIndex; 

//        StartCoroutine(PlayClips(chosenGroup));
        
//    }

//    IEnumerator PlayClips(AudioClipGroup clipGroup)
//    {
//        isPlaying = true;

//        if (chosenClipID == 0) {
//            foreach (AudioClip clip in clipGroup.audioClips)
//            {
//                audioSource.clip = clip;
//                audioSource.Play();
//                Debug.Log("Play" + clip);

//                int randomButton = Random.Range(0, buttons.Length);

//                //Change button colour to active
//                spriteRenderer = buttons[randomButton].GetComponent<SpriteRenderer>();
//                spriteRenderer.color = activeColour;

//                //StartCoroutine(ResetButton());
//                yield return new WaitForSeconds(1);
//            }
//        } else if (chosenClipID == 1) {
//            foreach (AudioClip clip in clipGroup.audioClips)
//            {
//                audioSource.clip = clip;
//                audioSource.Play();
//                Debug.Log("Play" + clip);

//                int randomButton1 = Random.Range(0, buttons.Length);
//                int randomButton2 = Random.Range(0, buttons.Length);

//                //Change button colour to active
//                spriteRenderer = buttons[randomButton1].GetComponent<SpriteRenderer>();
//                spriteRenderer.color = activeColour;
//                spriteRenderer = buttons[randomButton2].GetComponent<SpriteRenderer>();
//                spriteRenderer.color = activeColour;

//                //StartCoroutine(ResetButton());
//                yield return new WaitForSeconds(1);
//            }
//        }

//        isPlaying = false;
//    }

//    IEnumerator ResetButton()
//    {
//        spriteRenderer.color = inactiveColour;
//        yield return 0;
//    }
//}
