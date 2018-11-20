using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {

    public GameObject cameraManager;
    public GameObject tablet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetButtonDown("KeyPad_XButton"))
        {
            tablet.gameObject.SetActive(!tablet.gameObject.activeSelf);
        }

        if (Input.GetButtonDown("KeyPad_L1"))
        {
            tablet.gameObject.GetComponent<Tablet>().ChangeStete();
        }

        if (Input.GetButtonDown("KeyPad_R1"))
        {
            cameraManager.GetComponent<CameraManager>().ObjectCameraRoll();
        }

	}
}
