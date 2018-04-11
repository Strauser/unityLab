using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MovableObject {

    new public void Start() {
        base.StartWithParameter(new DefaultMovementManager(this));

        int x = Random.Range(0, Laby.size);
        int y = Random.Range(0, Laby.size);
        this.SetPosition(x, y);

        transform.Translate(new Vector3(x * Conf.tileSize, 0, y * Conf.tileSize));
    }

    void FixedUpdate() {

        MovementHelper.Direction direction = MovementHelper.Direction.NONE;

        float rand = Random.value;

        if (rand < .3)
            direction = MovementHelper.Direction.MOVE_FORWARD;
        else if (rand > .3 && rand < .5)
            direction = MovementHelper.Direction.TURN_RIGHT;
        else if (rand > .5 && rand < .7)
            direction = MovementHelper.Direction.TURN_LEFT;
        else if (rand > .7)
            direction = MovementHelper.Direction.MOVE_BACKWARD;

        Debug.Log(posX + " " + posY);

        mv.Move(posX, posY, direction, rb);

    }
    
}
