using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall {

    public class Direction
    {
        public float offsetX;
        public float offsetZ;
        public bool horizontal;

        public Direction(float offsetX, float offsetY, bool horizontal)
        {
            this.offsetX = offsetX;
            this.offsetZ = offsetY;
            this.horizontal = horizontal;
        }
    }

    public static Direction NORTH = new Direction(0f, 1.5f, true);
    public static Direction EAST = new Direction(1.5f, 0f, false);
    public static Direction SOUTH = new Direction(0f, -1.5f, true);
    public static Direction WEST = new Direction(-1.5f, 0f, false);

    private Tile tile;
    private Direction direction;
    private GameObject wallType;

    public Wall(Tile tile,  Direction direction, GameObject wallType)
    {
        this.tile = tile;
        this.direction = direction;
        this.wallType = wallType;
    }

    public void Instanciate()
    {
        GameObject wallObject = Object.Instantiate(wallType, new Vector3(tile.GetX()*3 + direction.offsetX , 1.0f, tile.GetY()*3 + direction.offsetZ), Quaternion.identity);
        if(direction.horizontal)
        {
            wallObject.transform.Rotate(new Vector3(0, 90, 0));
        }
    }

}
