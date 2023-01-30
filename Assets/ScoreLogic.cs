using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreLogic : MonoBehaviour
{
    public int timeAlive;
    public Text timeAliveText;
    public Text highScoreText;
    private bool isAlive = true;
    float timer = 0.0f;
    public float count = 0;

    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

 

    private void Update()
    {
        if (isAlive == true)
        {
            timer += Time.deltaTime;
            timeAlive = (int)((timer % 60) + (count * 60));
            if (timeAlive == 60)
            {
                count += 1;
            }
            addScore();
            checkHighScore();
        }

    }

    public void addScore()                   // Increments score text
    {
        timeAliveText.text = timeAlive.ToString();
    }

    void checkHighScore()                 // Checks if high score has been surpassed, updates high score if true
    {
        if (timeAlive > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", timeAlive);
            highScoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        }
    }



    public void setAlive(bool input)
    {
        isAlive = input;
    }
    public bool getAlive()
    {
        return isAlive;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
        setAlive(true);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

