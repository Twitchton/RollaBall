using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float timer = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    private Rigidbody rb;
    private float movementX, movementY;
    private int count;

    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetScoreText();
    }

    // Update is called once per frame
    void Update(){

        timer -= (Time.deltaTime);

        SetScoreText();
        SetTimerText();
    }

    //Function that updates score text on the GUI when called
    void SetScoreText()
    {
        scoreText.text = "Score:" + count.ToString();
    }

    //Function that updates the timer text on the GUI when called
    void SetTimerText()
    {
        timerText.text = "Timer\n" + timer.ToString();
    }

    //Function called when player movement is called
    void OnMove(InputValue movementValue){

        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    //function called at set intervals
    void FixedUpdate(){

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement*speed);
    }

    //calls function when colliding with a trigger 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            count++;
        }
       
    }

}
