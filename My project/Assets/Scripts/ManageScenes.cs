using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public static ManageScenes instance;

    [SerializeField] string[] scenes;
    public int scene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StarGame()
    {
        SceneManager.LoadScene(0);
        PlayThroughtData.instance.clearStage[0] = true;        
    }

    public void BackToTitleScreen()
    {
        SceneManager.LoadScene(2);        
        PlayThroughtData.instance.RestartData();

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(scenes[scene]);
        scene++;
    }

    public void FinalScreen()
    {
        SceneManager.LoadScene(3);
    }
    
}
