using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : LivingEntity {

    new public void Start() {
        base.StartWithParameter(new DefaultMovementManager(this));
        this.isBlocking = true;

        int x = Random.Range(0, Laby.size);
        int y = Random.Range(0, Laby.size);
        this.SetPosition(x, y);

        transform.Translate(new Vector3(x * Conf.tileSize, 0, y * Conf.tileSize));
    }


    override public bool PrepareMovement(MovementHelper.Direction playerDirection)
    {
    
        MovementHelper.Direction direction = MovementHelper.Direction.NONE;

        float rand = Random.value;

        if (rand < .3)
            direction = MovementHelper.Direction.MOVE_FORWARD;
        else if (rand > .3 && rand < .5)
            direction = MovementHelper.Direction.STRAFE_RIGHT;
        else if (rand > .5 && rand < .7)
            direction = MovementHelper.Direction.STRAFE_LEFT;
        else if (rand > .7)
            direction = MovementHelper.Direction.MOVE_BACKWARD;

        mv.PrepareMovement(posX, posY, direction);

        return false;

    }
    
}
