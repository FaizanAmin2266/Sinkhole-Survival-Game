using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public int timeAlive;
    public Text timeAliveText;
    ScoreLogic scorelog;
    //private bool isAlive = true;
    //float timer = 0.0f;
    public float count = 0;
    public GameObject gameOverScreen;
    public GameObject TouchInput;

    public Animator animator;

    private void Start()
    {
        scorelog = GameObject.FindGameObjectWithTag("Logic2").GetComponent<ScoreLogic>();
    }

    private void Update()
    {
        //if(isAlive == true)
        //{
        //    timer += Time.deltaTime;
        //    timeAlive = (int)((timer % 60) + (count * 60));
        //    if (timeAlive == 60)
        //    {
        //        count += 1;
        //    }
        //    addScore();
        //}
        
    }

    //public void addScore()
    //{
    //    timeAliveText.text = timeAlive.ToString();
    //}



    //public void setAlive(bool input)
    //{
    //    this.isAlive = input;
    //}
    //public bool getAlive()
    //{
    //    return isAlive;
    //}

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SoundScript.soundInstance.Audio.PlayOneShot(SoundScript.soundInstance.buttonClick);
    }

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
        scorelog.setAlive(true);
        SoundScript.soundInstance.Audio.PlayOneShot(SoundScript.soundInstance.buttonClick);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SoundScript.soundInstance.Audio.PlayOneShot(SoundScript.soundInstance.buttonClick);
    }

    public void gameOver()
    {
        scorelog.setAlive(false);
        animator.SetBool("isDead", true);
        TouchInput.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
