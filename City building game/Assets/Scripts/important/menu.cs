using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void continueButton()
    {

    }
    public void newGamebutton()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
    public void loadGameButton()
    {

    }
    public void optionsButton()
    {

    }
    public void credits()
    {

    }
    public void exitButton()
    {
        Debug.Log("exit");
        Application.Quit();
    }


}
