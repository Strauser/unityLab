using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laby : MonoBehaviour {

    public Tile[][] board;
    public GameObject tileType;
    public GameObject wallType;

    public static int size = 4;
    public static float wallProba = 0.4f;

    void Start () {
        

        for (int x = 0; x < size; x++)
        {
            for (int z = 0 ; z < size; z++)
            {
                Tile tile = new Tile(x, z, tileType, wallType);
                tile.Instanciate();
            }
        }

	}
	
}
