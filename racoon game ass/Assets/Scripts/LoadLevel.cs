using System;
using Unity.Hierarchy;
using UnityEditor.SearchService;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] string[] levelNames;
    private int levelIndexCurrentlyLoaded = -1;

    void LoadLevelNumeric_ClearOld(int index)
    {
        if (levelIndexCurrentlyLoaded <= 0)
        {
            SceneManager.UnloadSceneAsync(levelIndexCurrentlyLoaded);
        }
        SceneManager.LoadScene(levelNames[index], LoadSceneMode.Additive);
        levelIndexCurrentlyLoaded = index;
    }

    void LoadLevelNumeric_LeaveOld(int index)
    {
        SceneManager.LoadScene(levelNames[index], LoadSceneMode.Additive);
    }

    void LoadLevelName(string name)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }    
    void UnloadLevelName(string name)
    {
        SceneManager.UnloadSceneAsync(name);
    }
}
