using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: LivingEntity {

    public Canvas canvas;

    new public void Start() {
        base.StartWithParameter(new DefaultMovementManager(this), 20);
        this.isBlocking = true;

        health.bar.transform.SetParent(canvas.transform);
        health.bar.transform.position = new Vector3(100, 600, 0);
    }
    
}
