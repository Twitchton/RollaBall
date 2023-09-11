using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX, movementY;
    public float speed=0;

    // Start is called before the first frame update
    void Start(){

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){

        
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


}
