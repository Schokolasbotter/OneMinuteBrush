using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public GameObject creditObject, menuObject, controlsObject;
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void openCredits()
    {
        controlsObject.SetActive(false);
        menuObject.SetActive(false);
        creditObject.SetActive(true);
    }

    public void openMenu()
    {
        controlsObject.SetActive(false);
        creditObject.SetActive(false);
        menuObject.SetActive(true);
    }
    public void openControls()
    {
        creditObject.SetActive(false);
        menuObject.SetActive(false);
        controlsObject.SetActive(true);
    }
}
