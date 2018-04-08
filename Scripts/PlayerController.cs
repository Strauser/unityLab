using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;

    private static Vector3 noMovement = new Vector3(0, 0, 0);

    private bool isMoving = false;
    private int framesLeftToMove = 0;
    private int pauseFrames = 0;
    private Vector3 movement = noMovement;

    public int moveTimer;
    public int pauseTimer;
    private float speed;

    private int posX;
    private int posY;

    void Start()
    {
        posX = 0;
        posY = 0;
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

        Tile currentTile = Laby.board[posX, posY];

        if (right && !up && !down && !left && currentTile.wallE == null)
        {
            futureMovement = new Vector3(1, 0.0f, 0);
            newMovement = true;
            posX += 1;
            Debug.Log(posX + " " + posY);
        }

        else if (left && !up && !down && !right && currentTile.wallW == null)
        {
            futureMovement = new Vector3(-1, 0.0f, 0);
            newMovement = true;
            posX -= 1;
            Debug.Log(posX + " " + posY);
        }

        else if (up && !down && !left && !right && currentTile.wallN == null)
        {
            futureMovement = new Vector3(0, 0.0f, 1);
            newMovement = true;
            posY += 1;
            Debug.Log(posX + " " + posY);
        }

        else if (down && !up && !left && !right && currentTile.wallS == null)
        {
            futureMovement = new Vector3(0, 0.0f, -1);
            newMovement = true;
            posY -= 1;
            Debug.Log(posX + " " + posY);
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

