using UnityEngine;
using UnityEngine.Advertisements;

public class TestAd : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener, IUnityAdsLoadListener
{
    [SerializeField] private string _androidGameId = "YOUR_ANDROID_GAME_ID";
    [SerializeField] private string _iosGameId = "YOUR_IOS_GAME_ID";
    [SerializeField] private bool _testMode = true;
    private string _adUnitId;

    void Start()
    {
        string gameId = Application.platform == RuntimePlatform.IPhonePlayer ? _iosGameId : _androidGameId;
        Advertisement.Initialize(gameId, _testMode, this);

        _adUnitId = Application.platform == RuntimePlatform.IPhonePlayer ? "Interstitial_iOS" : "Interstitial_Android";
        Advertisement.Load(_adUnitId, this);
    }

    public void ShowTestAd()
    {
        Debug.Log("Attempting to show ad...");
        Advertisement.Show(_adUnitId, this);
    }

    public void OnUnityAdsInitializationComplete()
    {
        Debug.Log("Ads initialized successfully.");
    }

    public void OnUnityAdsInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError($"Initialization Failed: {error} - {message}");
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log($"Ad Loaded: {adUnitId}");
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Ad Failed to Load: {error} - {message}");
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) { }
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message) { }
    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    public void OnInitializationComplete()
    {
        Debug.Log("Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError($"Ads initialization failed: {error.ToString()} - {message}");
    }
}