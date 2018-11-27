using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    [SerializeField]private float rotate_speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        rotateCameraAngle();

	}

    //TODO:カメラの角度変更及び、制限
    void rotateCameraAngle()
    {
        Vector3 angle = new Vector3(
            Input.GetAxis("R_Horizontal") * rotate_speed,
            0,
            0
            );

        this.transform.localEulerAngles += angle;
    }
}

