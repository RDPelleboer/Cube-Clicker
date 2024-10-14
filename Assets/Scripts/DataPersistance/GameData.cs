using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int highScore;

    // The value defined in this constructor will be the default values
    // The game starts with when there's no data
    public GameData()
    {
        this.highScore = 0;
    }
}
