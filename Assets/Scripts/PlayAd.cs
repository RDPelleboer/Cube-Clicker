using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAd : MonoBehaviour
{
    private InterstitialAdExample interstitialAd;

    // Start is called before the first frame update
    void Start()
    {
        interstitialAd = FindObjectOfType<InterstitialAdExample>();

        interstitialAd.LoadAd();

        interstitialAd.ShowAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
