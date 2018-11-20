using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngle : MonoBehaviour {

    public float rotate_speed;
    public GameObject player;

    private const float ANGLE_LIMIT_UP = 60f;
    private const float ANGLE_LIMIT_DOWN = -60f;

	// Update is called once per frame
	void Update () {

        transform.position = player.transform.position;

        rotateCameraAngle();

        float angle_x = 180f <= transform.eulerAngles.x ? transform.transform.eulerAngles.x - 360 : transform.eulerAngles.x;
        transform.eulerAngles = new Vector3(Mathf.Clamp(angle_x, ANGLE_LIMIT_DOWN, ANGLE_LIMIT_UP),
            transform.eulerAngles.y,transform.eulerAngles.z);

	}

    void rotateCameraAngle()
    {
        Vector3 angle = new Vector3(
            0,
            Input.GetAxis("R_Vertical") * rotate_speed,
            0
            );

        transform.eulerAngles += new Vector3(angle.y, angle.x);
    }
}
