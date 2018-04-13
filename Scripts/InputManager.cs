using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    bool inAction = false;
    public Player player;
    List<MovableObject> movableObjects;
    

    private void Update() {

        MovementHelper.Direction direction = MovementHelper.Direction.NONE;
        
        if (Input.GetKey(KeyCode.UpArrow))
            direction = MovementHelper.Direction.MOVE_FORWARD;
        else if (Input.GetKey(KeyCode.DownArrow))
            direction = MovementHelper.Direction.MOVE_BACKWARD;
        else if (Input.GetKey(KeyCode.LeftArrow))
            direction = MovementHelper.Direction.TURN_LEFT;
        else if (Input.GetKey(KeyCode.RightArrow))
            direction = MovementHelper.Direction.TURN_RIGHT;

        if (direction != MovementHelper.Direction.NONE) {
            player.PrepareMovement(direction);
        }
        
    }

    private void FixedUpdate() {
        player.Move();
    }
}
