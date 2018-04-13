using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laby : MonoBehaviour {

    public static int size = 20;
    
    public static Tile[,] board = new Tile[size, size];
    public GameObject tileType;
    public GameObject wallType;

    void Start () {
        
        for (int x = 0; x < size; x++)
        {
            for (int y = 0 ; y < size; y++)
            {
                Tile tile = new Tile(x, y, tileType, wallType);
                board[x, y] = tile;
                tile.Instanciate(this.transform);
            }
        }

        updateTiles();

    }

    private void updateTiles()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                if(x > 0 && board[x-1, y].hasWall(Wall.EAST)) {
                    board[x, y].AddWall(Wall.WEST, null);
                }

                if (y > 0 && board[x, y-1].hasWall(Wall.NORTH)) {
                    board[x, y].AddWall(Wall.SOUTH, null);
                }
            }
        }
    }
    
}
