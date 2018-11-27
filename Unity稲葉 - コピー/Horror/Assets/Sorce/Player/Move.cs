using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float speed;
    public GameObject playerCamera;
    public float rotate_speed;
    private float current_speed;

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

        Dash();

        if (Input.GetAxis("Vertical") > 0.7f)
        {
            transform.position += transform.TransformDirection(Vector3.forward) * current_speed;
        }

        if (Input.GetAxis("Vertical") < -0.7f)
        {
            transform.position += transform.TransformDirection(Vector3.back) * current_speed;
        }

        if(Input.GetAxis("Horizontal") > 0.7f)
        {
            transform.position += transform.TransformDirection(Vector3.right) * (current_speed / 2);
        }

        if (Input.GetAxis("Horizontal") < -0.7f)
        {
            transform.position += transform.TransformDirection(Vector3.left) * (current_speed / 2);
        }
    }

    void Dash()
    {
        if (Input.GetButton("KeyPad_R1"))
        {
            current_speed = speed * 2;
        }
        else
        {
            current_speed = speed;
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
