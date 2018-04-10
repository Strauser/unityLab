using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionableObject : MonoBehaviour {

    public int posX;
    public int posY;

    public PositionableObject(int posX = 0, int posY = 0) {
        this.posX = posX;
        this.posY = posY;
    }
    
}
