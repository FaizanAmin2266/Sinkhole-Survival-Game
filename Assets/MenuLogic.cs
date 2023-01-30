using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public GameObject mainScreen;
    public GameObject howToPlayScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
        SoundScript.soundInstance.Audio.PlayOneShot(SoundScript.soundInstance.buttonClick);
    }

    public void howToPlay()
    {
        mainScreen.SetActive(false);
        howToPlayScreen.SetActive(true);
        SoundScript.soundInstance.Audio.PlayOneShot(SoundScript.soundInstance.buttonClick);
    }

    public void backToMenu()
    {
        howToPlayScreen.SetActive(false);
        mainScreen.SetActive(true);
        SoundScript.soundInstance.Audio.PlayOneShot(SoundScript.soundInstance.buttonClick);
    }
}
