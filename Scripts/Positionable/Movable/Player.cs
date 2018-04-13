using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MovableObject {

    new public void Start() {
        base.StartWithParameter(new DefaultMovementManager(this));
        this.isBlocking = true;
    }
    
}
