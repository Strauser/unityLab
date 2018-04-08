using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

    private int x;
    private int y;

    private GameObject tileType;
   
    public Wall wallN;
    public Wall wallE;
    public Wall wallS;
    public Wall wallW;

    List<Wall> walls = new List<Wall>();

    public Tile(int x, int y, GameObject tileType, GameObject wallType)
    {
        this.x = x;
        this.y = y;

        this.tileType = tileType;

        if(y == Laby.size-1 || Random.value < Laby.wallProba)
        { 
            wallN = new Wall(this, Wall.NORTH, wallType);
            walls.Add(wallN);
        }
        if (x == Laby.size - 1 || Random.value < Laby.wallProba)
        {
            wallE = new Wall(this, Wall.EAST, wallType);
            walls.Add(wallE);
        }
        if (y == 0)
        {
            wallS = new Wall(this, Wall.SOUTH, wallType);
            walls.Add(wallS);
        }
        if (x == 0)
        {
            wallW = new Wall(this, Wall.WEST, wallType);
            walls.Add(wallW);
        }

    }

    public void Instanciate()
    {
        Object.Instantiate(tileType, new Vector3(x*Laby.tileSize, 0, y* Laby.tileSize), Quaternion.identity);

        foreach (Wall w in walls)
        {
            if (w != null)
            {
                w.Instanciate();
            }
        }
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
