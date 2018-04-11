using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionableObject : MonoBehaviour {

    public int posX;
    public int posY;

    public Rigidbody rb;

    public void Start() {
        this.posX = 0;
        this.posY = 0;

        rb = GetComponent<Rigidbody>();
    }

    public void SetPosition(int posX, int posY) {
        this.posX = posX;
        this.posY = posY;
    }


    
}
