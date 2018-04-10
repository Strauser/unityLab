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

    public void Move(MovementHelper.Direction direction) {
        mv.Move(posX, posY, direction, rb);
    }

}
