using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveFile
{
    public int currentStage;
    public int lives;
    public int currentScore;
    public bool[] clearStage;

    public SaveFile() 
    {
        currentStage = 0;
        lives = 5;
        currentScore = 0;
        clearStage = new bool[3];
    }

    public SaveFile(int currentStage, int lives, int currentScore, bool[] clearStage)
    {
        this.currentStage = currentStage;
        this.lives = lives;
        this.currentScore = currentScore;
        this.clearStage = clearStage;
    }
}
