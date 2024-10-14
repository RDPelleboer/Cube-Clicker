using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour, IDataPersistance
{
    public int points;
    public int highScore;
    public TMP_Text scoreText;

    [Header("End screen menu")]
    public GameObject endMenu;
    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;
    public TMP_Text newHighScoreMessage;

    public void LoadData(GameData data)
    {
        this.highScore = data.highScore;
    }

    public void SaveData(ref GameData data)
    {
        data.highScore = this.highScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(highScore);
    }

    public void UpdateScore(int extraPoints)
    {
        points = points + extraPoints;
        scoreText.text = "Score: " + points.ToString();
    }

    public void EndMenu()
    {
        endMenu.SetActive(true);
        finalScoreText.text = points.ToString();

        if (points > highScore) { 
            highScore = points;
            highScoreText.text = points.ToString();
            DataPersistanceManager.instance.SaveGame();
            newHighScoreMessage.gameObject.SetActive(true);
        } else
        {
            highScoreText.text = highScore.ToString();
        }
    }
}
