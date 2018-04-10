﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovableObject {

    private Rigidbody rb;
    private MovementManager movementManager;
    
    void Start() {
        posX = 0;
        posY = 0;
        rb = GetComponent<Rigidbody>();

        movementManager = new MovementManager(this);
    }

    void FixedUpdate() {

        MovementHelper.Direction direction = MovementHelper.Direction.NONE;

        if (Input.GetKey(KeyCode.UpArrow))
            direction = MovementHelper.Direction.MOVE_FORWARD;
        else if(Input.GetKey(KeyCode.DownArrow))
            direction = MovementHelper.Direction.MOVE_BACKWARD;
        else if(Input.GetKey(KeyCode.LeftArrow))
            direction = MovementHelper.Direction.TURN_LEFT;
        else if(Input.GetKey(KeyCode.RightArrow))
            direction = MovementHelper.Direction.TURN_RIGHT;

        movementManager.Move(posX, posY, direction, rb);

    }

    public void UpdateMovement(MovementHelper.Orientation orientation) {

    }

}
