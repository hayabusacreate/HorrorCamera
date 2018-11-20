using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float speed = 0.1f;
    public GameObject playerCamera;
    public float rotate_speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Movement();
        rotateCameraAngle();

	}

    void Movement()
    {
        if(Input.GetAxis("Vertical") > 0.7f)
        {
            transform.position += transform.TransformDirection(Vector3.forward) * speed;
        }

        if (Input.GetAxis("Vertical") < -0.7f)
        {
            transform.position += transform.TransformDirection(Vector3.back) * speed;
        }
        if (Input.GetAxis("Horizontal") > 0.7f)
        {
            transform.position += transform.TransformDirection(Vector3.right) * speed;
        }
        if (Input.GetAxis("Horizontal") < -0.7f)
        {
            transform.position += transform.TransformDirection(Vector3.left) * speed;
        }
    }

    void rotateCameraAngle()
    {
        Vector3 angle = new Vector3(
            Input.GetAxis("R_Horizontal") * rotate_speed,
            0,
            0
            );

        transform.eulerAngles += new Vector3(angle.y, angle.x);
    }
}
