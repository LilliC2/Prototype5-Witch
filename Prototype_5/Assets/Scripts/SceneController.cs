using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class SceneController : GameBehaviour<SceneController>
{

    public void OpenScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
