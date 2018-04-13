using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMovementManager : MovementManager {

    public DefaultMovementManager(MovableObject entity) : base(entity) { }

    override public void Move(int posX, int posY, Rigidbody rb)
    {
        
        if (framesLeftToMove > 0)
        {
            framesLeftToMove -= 1;
            if (isTranslate)
            {
                rb.transform.Translate(nextMove * Conf.moveSpeed);
            }
            else
            {
                rb.transform.Rotate(nextMove * Conf.rotateSpeed);
            }
        }

        if (framesLeftToMove == 0 && pauseFrames >= 0)
        {
            pauseFrames -= 1;
            nextMove = MovementHelper.noMovement;

            if (pauseFrames <= 0)
            {
                isMoving = false;
            }
        }
    }

    override public void PrepareMovement(int posX, int posY, MovementHelper.Direction direction)
    {

        if(isMoving) {
            return;
        }

        bool newMovement = false;
        Vector3 futureMovement = MovementHelper.noMovement;

        MovementHelper.Orientation orientation = MovementHelper.GetOrientation(entity.transform);

        if (direction == MovementHelper.Direction.TURN_RIGHT)
        {
            futureMovement = new Vector3(0, 90, 0);
            newMovement = true;
            isTranslate = false;
        }
        else if (direction == MovementHelper.Direction.TURN_LEFT)
        {
            futureMovement = new Vector3(0, -90, 0);
            newMovement = true;
            isTranslate = false;
        }
        else if (direction == MovementHelper.Direction.MOVE_FORWARD && MovementHelper.CanMoveInDirection(posX, posY, orientation))
        {
            futureMovement = new Vector3(0, 0.0f, 1);
            newMovement = true;
            isTranslate = true;

            switch (orientation)
            {
                case (MovementHelper.Orientation.NORTH): entity.posY += 1; break;
                case (MovementHelper.Orientation.EAST): entity.posX += 1; break;
                case (MovementHelper.Orientation.WEST): entity.posX -= 1; break;
                case (MovementHelper.Orientation.SOUTH): entity.posY -= 1; break;
            }

        }
        else
        {
            MovementHelper.Orientation oppositeOrientation = MovementHelper.GetOrientation(entity.transform, 180);
            if (direction == MovementHelper.Direction.MOVE_BACKWARD && MovementHelper.CanMoveInDirection(posX, posY, oppositeOrientation))
            {
                futureMovement = new Vector3(0, 0.0f, -1);
                newMovement = true;
                isTranslate = true;

                switch (orientation)
                {
                    case (MovementHelper.Orientation.NORTH): entity.posY -= 1; break;
                    case (MovementHelper.Orientation.EAST): entity.posX -= 1; break;
                    case (MovementHelper.Orientation.WEST): entity.posX += 1; break;
                    case (MovementHelper.Orientation.SOUTH): entity.posY += 1; break;
                }
            }
        }

        if (newMovement)
        {
            isMoving = true;
            framesLeftToMove = Conf.moveTimer;
            pauseFrames = Conf.pauseTimer;
        }

        nextMove = futureMovement;
    }
}
