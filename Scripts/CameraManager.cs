using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    
    public GameObject player;
    

    // Use this for initialization
    void Start () {
        
        Vector3 pos = player.transform.position;
        this.transform.position = new Vector3(pos.x, pos.y + .5f, pos.z);
        /*
        this.transform.position = new Vector3(3, 12, -10);
        this.transform.eulerAngles = new Vector3(45, 0, 0);*/
    }

    // Update is called once per frame
    void LateUpdate ()
    {
        Vector3 pos = player.transform.position;
        this.transform.position = new Vector3(pos.x, pos.y + .5f, pos.z);
        this.transform.eulerAngles = player.transform.eulerAngles;
    }
}
