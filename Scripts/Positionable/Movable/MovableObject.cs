using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : PositionableObject {

    public MovementManager mv;

    public void StartWithParameter(MovementManager mv) {
        this.mv = mv;
        Start();
    }

    new private void Start() {
        base.Start();
    }

    virtual public bool PrepareMovement(MovementHelper.Direction direction) {
        return mv.PrepareMovement(posX, posY, direction);
    }

    public void Move() {
        if(mv != null) { 
            mv.Move(posX, posY, rb);
        }
    }

    public void MoveOneTile(MovementHelper.Orientation orientation)
    {
        switch (orientation)
        {
            case (MovementHelper.Orientation.NORTH): posY += 1; break;
            case (MovementHelper.Orientation.EAST): posX += 1; break;
            case (MovementHelper.Orientation.WEST): posX -= 1; break;
            case (MovementHelper.Orientation.SOUTH): posY -= 1; break;
        }
    }

}
