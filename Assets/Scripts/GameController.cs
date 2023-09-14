using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference start, pause, restart;
    //Text
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI endtext;

    //UI
    public GameObject titleScreen;
    public GameObject GUI;
    public GameObject pauseScreen;
    public GameObject endScreen;

    //tracked values
    public float timer = 0;
    private int score;
    public int collectibles = 0;

    //state
    private string state;

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
        if (state == "start")
        {
            
        }
        timer -= (Time.deltaTime);

        SetScoreText();
        SetTimerText();
    }

    //Handles use of the submit key
    void onSubmit()
    {
        if (state == "start")
        {
            titleScreen.SetActive(false);
            GUI.SetActive(true);
        }

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
    void SetEndText()
    {

    }

    //Function that increases the score
    public void getPickup()
    {
        score++;
    }

    //initiates the game state
    void startGame()
    {
        score = 0;

        SetScoreText();
        SetTimerText();


    }

    //Function that pauses the game
    void pauseGame()
    {

    }

    //Function that returns to game state from pause state
    void continueGame()
    {

    }

    void finishGame()
    {

    }

}
