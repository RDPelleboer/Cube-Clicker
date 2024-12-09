using UnityEngine;
using UnityEngine.Advertisements;

#if UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR // Ensure this script is only compiled for supported platforms
public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
#if UNITY_ANDROID
    [SerializeField] private string _androidGameId;
#elif UNITY_IOS
    [SerializeField] private string _iOSGameId;
#endif

    [SerializeField] private bool _testMode = true;
    private string _gameId;

    void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
#if UNITY_IOS
        _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
        _gameId = "editorGameId"; // Mock ID for Editor testing
#endif

        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
#endif