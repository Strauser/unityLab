using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MovableObject {

    new public void Start() {
        base.StartWithParameter(new DefaultMovementManager(this));
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

        mv.Move(posX, posY, direction, rb);

    }
    

}
