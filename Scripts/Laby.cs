using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laby : MonoBehaviour {

    public static int size = 4;
    public static float wallProba = 0.4f;
    public static float tileSize = 3.0f;

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
                if(x > 0 && board[x-1, y].wallE != null)
                {
                    board[x, y].wallW = new Wall(board[x, y], Wall.WEST, null);
                }

                if (y > 0 && board[x, y-1].wallN != null)
                {
                    board[x, y].wallS = new Wall(board[x, y], Wall.SOUTH, null);
                }
            }
        }
    }
    
}
