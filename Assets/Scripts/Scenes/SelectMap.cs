using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour
{
    [SerializeField] private string mapScene;

    public void ChooseMap(string mapName)
    {
        mapScene = mapName;
    }

    public void StartGame()
    {
        if (mapScene == "")
            return;

        Setting.currentScene = mapScene;
        SceneManager.LoadScene(mapScene);
    }
}
