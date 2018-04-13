using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

    private int x;
    private int y;

    private GameObject tileType;

    List<Wall> walls = new List<Wall>();

    public Tile(int x, int y, GameObject tileType, GameObject wallType)
    {
        this.x = x;
        this.y = y;

        this.tileType = tileType;
        
        if (y == Laby.size-1) {
            AddWall(Wall.NORTH, wallType);
        }
        if (x == Laby.size - 1) {
            AddWall(Wall.EAST, wallType);
        }
        if (y == 0) {
            AddWall(Wall.SOUTH, wallType);
        }
        if (x == 0) {
            AddWall(Wall.WEST, wallType);
        }

        float rand = Random.value;

        if(rand > .1 && rand < .95) {
            if (Random.value > .5) AddWall(Wall.NORTH, wallType);
            else AddWall(Wall.EAST, wallType);
        } else if(rand > .95 && !hasWall(Wall.SOUTH) && !hasWall(Wall.WEST)) {
            AddWall(Wall.NORTH, wallType);
            AddWall(Wall.EAST, wallType);
        }

    }

    public void AddWall(Wall.Direction direction, GameObject wallType) {
        if(!hasWall(direction))
            walls.Add(new Wall(this, direction
                , wallType));
    }

    public void Instanciate(Transform laby) {
        GameObject newTile = Object.Instantiate(tileType, new Vector3(x*Conf.tileSize, 0, y* Conf.tileSize), Quaternion.identity);
        newTile.transform.parent = laby;

        foreach (Wall w in walls) {
            if (w != null) {
                w.Instanciate(newTile.transform);
            }
        }
    }


    public bool hasWall(Wall.Direction direction) {
        foreach(Wall wall in walls) {
            if (wall.direction.Equals(direction)) return true;
        }
        return false;
    }

    public int GetX()
    {   
        return x;
    }

    public int GetY()
    {
        return y;
    }

}
