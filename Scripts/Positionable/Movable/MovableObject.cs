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

    public void PrepareMovement(MovementHelper.Direction direction) {
        mv.PrepareMovement(posX, posY, direction);
    }

    public void Move() {
        mv.Move(posX, posY, rb);
    }

}
