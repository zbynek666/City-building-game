using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    public GameObject creditsscane;
    public GameObject optionsScane;
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
        optionsScane.SetActive(true);

    }
    public void credits()
    {
        creditsscane.SetActive(true);
    }
    public void exitButton()
    {
        Debug.Log("exit");
        EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void back()
    {
        creditsscane.SetActive(false);
        optionsScane.SetActive(false);


    }


}
