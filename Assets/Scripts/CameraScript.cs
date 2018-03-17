using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public static float offsetX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(RockScript.instance != null)
        {
            if(RockScript.instance.isAlive)
            {
                MoveTheCam();
            }
        }
	}

    void MoveTheCam()
    {
        Vector3 temp = transform.position;
        temp.x = RockScript.instance.GetPositionX() + offsetX;
        transform.position = temp;
    }
}
