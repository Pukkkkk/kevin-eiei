using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSide : MonoBehaviour
{
    [SerializeField] private string mainMenuScene;
    [SerializeField] private string chooseMapScene;

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void GoToChooseMap()
    {
        SceneManager.LoadScene(chooseMapScene);
    }

    public void ChooseSide(int i)
    {
        Setting.SelectSide(i);
        GoToChooseMap();
    }
}
