using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;

    private static Vector3 noMovement = new Vector3(0, 0, 0);

    private bool isMoving = false;
    private bool isTranslate = false;
    private int framesLeftToMove = 0;
    private int pauseFrames = 0;
    private Vector3 movement = noMovement;

    public int moveTimer;
    public int pauseTimer;
    private float moveSpeed;
    private float rotateSpeed;

    private int posX;
    private int posY;

    enum Orientation { NORTH, SOUTH, EAST, WEST};

    void Start() {
        posX = 0;
        posY = 0;
        moveSpeed = Laby.tileSize / moveTimer;
        rotateSpeed = 1.0f / moveTimer;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {

        if (!isMoving) {
            movement = PrepareMovement();
        }

        if (framesLeftToMove > 0) {
            framesLeftToMove -= 1;
            if(isTranslate) {
                rb.transform.Translate(movement * moveSpeed);
            } else {
                rb.transform.Rotate(movement * rotateSpeed);
            }
        }

        if (framesLeftToMove == 0 && pauseFrames >= 0) {
            pauseFrames -= 1;
            movement = noMovement;

            if(pauseFrames <= 0) {
                isMoving = false;
            }
        }
    }

    private Vector3 PrepareMovement() {

        bool newMovement = false;
        Vector3 futureMovement = noMovement;

        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);

        Orientation orientation = GetOrientation();

        if (right && !up && !down && !left) {
            futureMovement = new Vector3(0, 90, 0);
            newMovement = true;
            isTranslate = false;
        } else if (left && !up && !down && !right) {
            futureMovement = new Vector3(0, -90, 0);
            newMovement = true;
            isTranslate = false;
        } else if (up && !down && !left && !right && CanMoveInDirection(orientation)) {
            futureMovement = new Vector3(0, 0.0f, 1);
            newMovement = true;
            isTranslate = true;

            switch(orientation) {
                case (Orientation.NORTH): posY += 1; break;
                case (Orientation.EAST) : posX += 1; break;
                case (Orientation.WEST) : posX -= 1; break;
                case (Orientation.SOUTH): posY -= 1; break;
            }

        } else if (down && !up && !left && !right && CanMoveInDirection(GetOrientation(180))) {
            futureMovement = new Vector3(0, 0.0f, -1);
            newMovement = true;
            isTranslate = true;

            switch (orientation) {
                case (Orientation.NORTH): posY -= 1; break;
                case (Orientation.EAST) : posX -= 1; break;
                case (Orientation.WEST) : posX += 1; break;
                case (Orientation.SOUTH): posY += 1; break;
            }
        }

        if (newMovement) {
            isMoving = true;
            framesLeftToMove = moveTimer;
            pauseFrames = pauseTimer;
        }

        return futureMovement;
    }

    private bool CanMoveInDirection(Orientation orientation) {
        
        Tile currentTile = Laby.board[posX, posY];

        if (orientation == Orientation.NORTH && !currentTile.hasWall(Wall.NORTH))
            return true;
        else if (orientation == Orientation.EAST && !currentTile.hasWall(Wall.EAST))
            return true;
        else if (orientation == Orientation.WEST && !currentTile.hasWall(Wall.WEST))
            return true;
        else if (orientation == Orientation.SOUTH && !currentTile.hasWall(Wall.SOUTH))
            return true;

        return false;
    }

    private Orientation GetOrientation(int ajust = 0)
    {
        float orientation = (this.transform.rotation.eulerAngles.y + ajust) % 360;

        if (orientation > 359 || orientation < 1)
            return Orientation.NORTH;
        else if (orientation > 89 && orientation < 91)
            return Orientation.EAST;
        else if (orientation > 269 && orientation < 271)
            return Orientation.WEST;
        else 
            return Orientation.SOUTH;
    }
}
