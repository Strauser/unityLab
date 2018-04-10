using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementManager {

    public MovableObject entity;

    public bool isMoving = false;
    public bool isTranslate = false;
    public int framesLeftToMove = 0;
    public int pauseFrames = 0;

    public Vector3 movement = MovementHelper.noMovement;

    public MovementManager(MovableObject entity) {
        this.entity = entity;
    }
    
    abstract public void Move(int posX, int posY, MovementHelper.Direction direction, Rigidbody rb);

}
