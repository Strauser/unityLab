using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public Laby laby;
    public Player player;
    public InputManager inputManager;
    public Canvas canvas;

    public Monster monsterType;

	// Use this for initialization
	void Start () {
		
        for(int i = 0; i < 10; i++)
        {
            inputManager.AddMonster(Object.Instantiate(monsterType, new Vector3(0, 0.5f, 0), Quaternion.identity));
        }

	}


}
