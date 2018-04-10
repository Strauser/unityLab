﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager {

    private MovableObject entity;

    private bool isMoving = false;
    private bool isTranslate = false;
    private int framesLeftToMove = 0;
    private int pauseFrames = 0;

    private Vector3 movement = MovementHelper.noMovement;

    public MovementManager(MovableObject entity) {
        this.entity = entity;
    }

    public void Move(int posX, int posY, MovementHelper.Direction direction, Rigidbody rb) {

        if (!isMoving && direction != MovementHelper.Direction.NONE) {
            movement = PrepareMovement(posX, posY, direction);
        }

        if (framesLeftToMove > 0) {
            framesLeftToMove -= 1;
            if (isTranslate) {
                rb.transform.Translate(movement * Conf.moveSpeed);
            } else {
                rb.transform.Rotate(movement * Conf.rotateSpeed);
            }
        }

        if (framesLeftToMove == 0 && pauseFrames >= 0) {
            pauseFrames -= 1;
            movement = MovementHelper.noMovement;

            if (pauseFrames <= 0)
            {
                isMoving = false;
            }
        }
    }

    public Vector3 PrepareMovement(int posX, int posY, MovementHelper.Direction direction) {
       
        bool newMovement = false;
        Vector3 futureMovement = MovementHelper.noMovement;
        
        MovementHelper.Orientation orientation = MovementHelper.GetOrientation(entity.transform);

        if (direction == MovementHelper.Direction.TURN_RIGHT) {
            futureMovement = new Vector3(0, 90, 0);
            newMovement = true;
            isTranslate = false;
        } else if (direction == MovementHelper.Direction.TURN_LEFT) {
            futureMovement = new Vector3(0, -90, 0);
            newMovement = true;
            isTranslate = false;
        } else if (direction == MovementHelper.Direction.MOVE_FORWARD && MovementHelper.CanMoveInDirection(posX, posY, orientation)) {
            futureMovement = new Vector3(0, 0.0f, 1);
            newMovement = true;
            isTranslate = true;

            switch (orientation) {
                case (MovementHelper.Orientation.NORTH): entity.posY += 1; break;
                case (MovementHelper.Orientation.EAST) : entity.posX += 1; break;
                case (MovementHelper.Orientation.WEST) : entity.posX -= 1; break;
                case (MovementHelper.Orientation.SOUTH): entity.posY -= 1; break;
            }

        } else {
            MovementHelper.Orientation oppositeOrientation = MovementHelper.GetOrientation(entity.transform, 180);
            if (direction == MovementHelper.Direction.MOVE_BACKWARD && MovementHelper.CanMoveInDirection(posX, posY, oppositeOrientation))
            {
                futureMovement = new Vector3(0, 0.0f, -1);
                newMovement = true;
                isTranslate = true;

                switch (orientation)
                {
                    case (MovementHelper.Orientation.NORTH): entity.posY -= 1; break;
                    case (MovementHelper.Orientation.EAST) : entity.posX -= 1; break;
                    case (MovementHelper.Orientation.WEST) : entity.posX += 1; break;
                    case (MovementHelper.Orientation.SOUTH): entity.posY += 1; break;
                }
            }
        }

        if (newMovement) {
            isMoving = true;
            framesLeftToMove = Conf.moveTimer;
            pauseFrames = Conf.pauseTimer;
        }

        return futureMovement;
    }

}