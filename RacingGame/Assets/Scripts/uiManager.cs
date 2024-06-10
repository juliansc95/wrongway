using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score;
    private bool gameOver;
    [SerializeField] private Button[] buttons;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        score = 0;
        InvokeRepeating("scoreUpdate",1f,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score; 
    }

   public void gameOverCheck()
    {
        gameOver = true;
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    private void scoreUpdate()
    {
        if (!gameOver)
        {
            score += 10;    
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void instructions()
    {
        SceneManager.LoadScene("instructions");
    }
    
    
    
    
    
    
    
    public void Pause()
    {

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    

    public void mainMenu()
    {
        SceneManager.LoadScene("menuScene");
    }

    public void exit()
    {
        Application.Quit();
    }
}
