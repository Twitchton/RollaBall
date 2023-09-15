using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //keybinds
    [SerializeField]
    private InputActionReference start, pause, restart;

    //Text
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI endtext;
    public TextMeshProUGUI finalScore;

    //UI
    public GameObject titleScreen;
    public GameObject GUI;
    public GameObject pauseScreen;
    public GameObject endScreen;

    //tracked values
    public float timer = 0;
    [SerializeField] private float timeMod = 0;
    public int collectibles = 0;
    private int score, collected;
    

    //state
    private string state;

    private void OnEnable()
    {
        start.action.performed += startGame;
        pause.action.performed += pauseGame;
        restart.action.performed += restartGame;
    }

    private void OnDisable()
    {
        start.action.performed -= startGame;
        pause.action.performed -= pauseGame;
        restart.action.performed -= restartGame;
    }

    // Start is called before the first frame update
    void Start()
    {
        state = "start";

        titleScreen.SetActive(true);
        GUI.SetActive(false);
        pauseScreen.SetActive(false);
        endScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (state == "play")
        {
            timer -= (Time.deltaTime);

            SetScoreText();
            SetTimerText();
        }

        if (collected >= collectibles)
        {
            state = "finish";

            SetEndText(true);
            finishGame();
        }

        if (timer <= 0)
        {
            state = "finish";

            SetEndText(false);
            finishGame();
        }
        
    }

    //Function for starting the game from start menu
    private void startGame(InputAction.CallbackContext context)
    {
        if (state == "start")
        {
            state = "play";

            collected = 0;

            SetScoreText();
            SetTimerText();

            titleScreen.SetActive(false);
            GUI.SetActive(true);
        }
    }

    //Function that pauses the game
    private void pauseGame(InputAction.CallbackContext context)
    {
        Pause();
    }

    public void Pause()
    {
        if (state == "play")
        {
            state = "pause";
            Time.timeScale = 0;

            GUI.SetActive(false);
            pauseScreen.SetActive(true);
        }
        else if (state == "pause")
        {
            state = "play";
            Time.timeScale = 1;

            GUI.SetActive(true);
            pauseScreen.SetActive(false);
        }
    }

    //function that restarts the game
    private void restartGame(InputAction.CallbackContext context)
    {
        if (state != "start")
        {
            Restart();
        }
    }

    public void Restart()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Function that ends the game and diplsays player score
    void finishGame()
    {
        //score = (int)(score*timer/timeMod);
        finalScore.text = "Final Score: " + score.ToString();

        GUI.SetActive(false);
        endScreen.SetActive(true);
    }

    //Function that updates score text on the GUI when called
    void SetScoreText()
    {
        scoreText.text = "Score:" + score.ToString();
    }

    //Function that updates the timer text on the GUI when called
    void SetTimerText()
    {
        timerText.text = "Timer\n" + timer.ToString("F2");
    }

    //Function that sets the end text 
    void SetEndText(bool win)
    {
        if (win)
        {
            endtext.text = "You WIN!";
        }
        else
        {
            endtext.text = "You Lose... :(";
        }
    }

    //Function that increases the score
    public void getPickup()
    {
        collected++;
        score = collected * 100;
    }

    //Function that exits the game
    public void Quit()
    {
        Application.Quit();
    }
}
