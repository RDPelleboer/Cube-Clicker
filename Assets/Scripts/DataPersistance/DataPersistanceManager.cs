using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    
    private GameData gameData;

    private List<IDataPersistance> DataPersistanceObjects;

    private FileDataHandler dataHandler;

    //Syntax means you can get the data publically, but can only change is privately
    public static DataPersistanceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one data persistance manager in the scene");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.DataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame(); 
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //TODO - load any saved data from a file using the data handler
        this.gameData = dataHandler.Load();

        //If no data can be loaded, initialise a new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initialising data to defaults");
            NewGame();
        }

        // push the loaded data to all other scripts that need it
        foreach (IDataPersistance dataPersistanceObj in DataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        // pass the data to other scripts so that they can update it
        foreach (IDataPersistance dataPersistanceObj in DataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }

        //TODO - Save that data to a file using the data handler
        dataHandler.Save(gameData);
    }

    //private void OnApplicationQuit()
    //{
    //    SaveGame();
    //}

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistance>();
    
    return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
