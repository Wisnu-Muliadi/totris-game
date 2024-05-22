using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ButtonScript : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.UnloadSceneAsync(1);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(2);
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
