using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;

    private bool isMoving = false;

    private int framesLeftToMove = 0;
    private int pauseFrames = 0;
    private static Vector3 noMovement = new Vector3(0, 0, 0);
    private Vector3 movement = noMovement;

    public int moveTimer;
    public int pauseTimer;
    private float speed;

    void Start()
    {
        speed = Laby.tileSize / moveTimer;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isMoving)
        {
            movement = prepareMovement();
        }

        if (framesLeftToMove > 0)
        {
            framesLeftToMove -= 1;
            rb.transform.Translate(movement * speed);
        }

        if (framesLeftToMove == 0 && pauseFrames >= 0)
        {
            pauseFrames -= 1;
            movement = noMovement;

            if(pauseFrames <= 0)
            {
                isMoving = false;
            }
        }
    }

    private Vector3 prepareMovement()
    {

        bool newMovement = false;
        Vector3 futureMovement = noMovement;

        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);

        if (right && !up && !down && !left)
        {
            futureMovement = new Vector3(-1, 0.0f, 0);
            newMovement = true;
        }

        else if (left && !up && !down && !right)
        {
            futureMovement = new Vector3(1, 0.0f, 0);
            newMovement = true;
        }

        else if (up && !down && !left && !right)
        {
            futureMovement = new Vector3(0, 0.0f, -1);
            newMovement = true;
        }

        else if (down && !up && !left && !right)
        {
            futureMovement = new Vector3(0, 0.0f, 1);
            newMovement = true;
        }

        if (newMovement)
        {
            isMoving = true;
            framesLeftToMove = moveTimer;
            pauseFrames = pauseTimer;
        }

        return futureMovement;
    }
}

