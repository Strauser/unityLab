using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    
    public Player player;
    List<MovableObject> movableObjects = new List<MovableObject>();
    

    private void Update() {

        MovementHelper.Direction direction = MovementHelper.Direction.NONE;

        if (Input.GetKey(KeyCode.X))
            player.TakeDamage(1);
        if (Input.GetKey(KeyCode.C))
            player.Heal(1);

        if (Input.GetKey(KeyCode.UpArrow))
            direction = MovementHelper.Direction.MOVE_FORWARD;
        else if (Input.GetKey(KeyCode.DownArrow))
            direction = MovementHelper.Direction.MOVE_BACKWARD;
        else if (Input.GetKey(KeyCode.LeftArrow))
            direction = MovementHelper.Direction.TURN_LEFT;
        else if (Input.GetKey(KeyCode.RightArrow))
            direction = MovementHelper.Direction.TURN_RIGHT;
        else if (Input.GetKey(KeyCode.J))
            direction = MovementHelper.Direction.STRAFE_LEFT;
        else if (Input.GetKey(KeyCode.K))
            direction = MovementHelper.Direction.STRAFE_RIGHT;

        if (direction != MovementHelper.Direction.NONE) {
            bool playerIsMoving = player.PrepareMovement(direction);

            if(playerIsMoving) { 
                foreach (MovableObject m in movableObjects) {
                    m.PrepareMovement(direction);
                }
            }
        }


    }

    private void FixedUpdate() {
        if(player.mv != null) { 
            player.Move();
        }

        foreach (MovableObject m in movableObjects) {
            m.Move();
        }
    }

    public void AddMonster(MovableObject entity)
    {
        movableObjects.Add(entity);
    }
}
