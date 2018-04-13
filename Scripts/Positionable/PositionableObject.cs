using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PositionableObject : MonoBehaviour {

    public int posX;
    public int posY;

    public bool isBlocking = false;

    public Rigidbody rb;

    public void Start() {
        this.posX = 0;
        this.posY = 0;

        rb = GetComponent<Rigidbody>();
        Laby.AddToTheMaze(this);
    }

    public void SetPosition(int posX, int posY) {
        this.posX = posX;
        this.posY = posY;
    }
    
}
