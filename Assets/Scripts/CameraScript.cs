using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform cameraTransform;
    public GameObject playerTransform;
	// Update is called once per frame

    void Start()
    {

    }
	void FixedUpdate () {
        playerTransform = GameObject.FindWithTag("Player");
        cameraTransform.position = new Vector3(playerTransform.transform.position.x, playerTransform.transform.position.y,cameraTransform.position.z);


    }
}
