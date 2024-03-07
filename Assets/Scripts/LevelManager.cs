using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public string Level1;
    public static LevelManager Instance {  get { return instance; } }
    public enum LevelStatus
    {
        Locked,
        Unlocked,
        Completed
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if(GetLevelStatus(Level1) == LevelStatus.Locked)//Just Installed the game
        {
            SetLevelStatus(Level1, LevelStatus.Unlocked);
        }
    }
    public LevelStatus GetLevelStatus(string levelName)
    {
        LevelStatus status =  (LevelStatus)PlayerPrefs.GetInt(levelName,0);
        return status;
    }

    public void SetLevelStatus(string levelName, LevelStatus status)
    {
        PlayerPrefs.SetInt(levelName, (int)status);
        Debug.Log("Setting "+ levelName +" Status "+ status);
    }

    public void MarkCurrentLevelComplete()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        int currentsceneindex = currentscene.buildIndex;
        SetLevelStatus(currentscene.name,LevelStatus.Completed);
        int nextsceneindex = currentsceneindex + 1;
        if (nextsceneindex <= SceneManager.sceneCountInBuildSettings)
        {
            SetLevelStatus(GetSceneNameByBuildIndex(nextsceneindex), LevelStatus.Unlocked);
        }
    }

    private string GetSceneNameByBuildIndex(int buildIndex)
    {
        string scenePath = SceneUtility.GetScenePathByBuildIndex(buildIndex);
        return Path.GetFileNameWithoutExtension(scenePath);
    }
}
