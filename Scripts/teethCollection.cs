using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class teethCollection : MonoBehaviour
{
    public List<toothScript> toothList;

    public TextMeshProUGUI timerText, screenText;
    public float timer = 60f;
    public bool gameOn = false;
    public int dirtPerLevel= 5, totalDirt = 5, level = 1;
    public GameObject playUI, endUI;
    public AudioClip successClip;

    // Update is called once per frame
    void Update()
    {
        //Set timer
        timerText.text = getTimerFormat(timer); 

        if (gameOn)
        {
            //Reduce Timer when Game is Playing
            timer -= Time.deltaTime;
            //Check Dirt Levels
            int dirtCounting = 0;
            foreach(toothScript tooth in toothList)
            {
                dirtCounting += tooth.dirtLevel;
            }
            if(dirtCounting == 0)
            {
                //Level Clear
                StartCoroutine(levelClear());
            }
            //When Timer Runs out
            if(timer <= 0f)
            {
                StartCoroutine(lostGame());
            }
        }

    }

    public void startGame()
    {
        endUI.SetActive(false);
        playUI.SetActive(true);

        if (!gameOn)
        {
            StartCoroutine(showScreenText("Level " + level.ToString()));
            timer = 60;
            gameOn = true;
            totalDirt = dirtPerLevel * level;
            //Distribute Dirt
            while (totalDirt > 0)
            {
                int randomNumber = Random.Range(0, 5);
                int toothNumber = Random.Range(0, 23);
                toothList[toothNumber].dirtLevel = randomNumber;
                totalDirt -= randomNumber;

            }
        }
    }

    private IEnumerator lostGame()
    {
        gameOn = false;
        StartCoroutine(showScreenText("Time out!"));
        yield return new WaitForSeconds(2.1f);
        //Show End Screen UI
        playUI.SetActive(false);
        endUI.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "You reached Level " + level.ToString();
        endUI.SetActive(true);
        level = 1;
    }

    private IEnumerator levelClear()
    {
        gameOn = false;
        StartCoroutine(showScreenText("CLEAR!"));
        GameObject.Find("SoundEffect").GetComponent<AudioSource>().PlayOneShot(successClip);
        yield return new WaitForSeconds(2f);
        level++;
        startGame();
        
    }

    private string getTimerFormat(float timer)
    {
        int minutes = 0;
        int seconds = 0;
        string timerString;

        while(timer > 60)
        {
            minutes++;
            timer -= 60;
        }
        seconds = Mathf.RoundToInt(timer);
        string secondString;
        if (seconds < 10)
        {
            secondString = "0"+seconds.ToString();
        }
        else
        {
            secondString = seconds.ToString();
        }
        timerString = minutes.ToString() + ":" + secondString;
        return timerString;
    }

    private IEnumerator showScreenText(string text)
    {
        screenText.text = text;
        screenText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        screenText.gameObject.SetActive(false);
    }


    public void goToMainMenu() 
    {
        StartCoroutine(GoToMainMenu()); 
    }

    public IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(0.3f);
        if (GameObject.Find("Music"))
        {
            Destroy(GameObject.Find("Music"));
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
