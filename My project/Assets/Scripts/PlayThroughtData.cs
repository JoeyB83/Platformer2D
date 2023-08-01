using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayThroughtData : MonoBehaviour
{
    public static PlayThroughtData instance;

    public int currentStage;
    public int lives;
    public int currentScore;
    public bool[] clearStage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    void Start()
    {
        LoadSaveData();        
    }

    void LoadSaveData()
    {
        SaveFile saveFile = SaveSystem.LoadData();

        currentStage = saveFile.currentStage;
        lives = saveFile.lives;
        currentScore = saveFile.currentScore;
        clearStage = saveFile.clearStage;
    }

    void SaveData()
    {
        SaveFile saveFile = new SaveFile(currentStage, lives, currentScore, clearStage);
        SaveSystem.SaveData(saveFile);
    }

    //[ContextMenu("DATA PATH")]
    //void VerRutaDATAPATH()
    //{
    //    Debug.Log(Application.persistentDataPath);
    //}

    public void RestartData()
    {
        SaveFile savefile = new SaveFile();
        SaveSystem.SaveData(savefile);

        this.currentStage = savefile.currentStage;
        this.lives= savefile.lives;
        this.currentScore= savefile.currentScore;
        this.clearStage= savefile.clearStage;

        ManageScenes.instance.scene = 0;
    }
    
    public void ScoreKill()
    {
        currentScore = currentScore + 10;

        SaveFile savefile = SaveSystem.LoadData();
        savefile.currentScore = currentScore;
        SaveSystem.SaveData(savefile);
    }

    public void LostLive()
    {
        lives--;

        SaveFile savefile = SaveSystem.LoadData();
        savefile.lives = lives;
        SaveSystem.SaveData(savefile);
    }
}
