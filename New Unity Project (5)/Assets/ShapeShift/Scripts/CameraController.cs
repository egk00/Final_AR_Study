using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    private Vector3 cameraDefaultPosition = new Vector3(-10f,8f,-10f);// This is the default Camera Position
    public Camera maincamera;
    private void Awake()
    {
       Instance = this;// Create An Instance of "this" script
       CameraDefaultPosition();// Set Camera Position When The scene Loads
       
    }
    public void CameraDefaultPosition()
    {
        this.transform.localPosition = cameraDefaultPosition;// set the local position of the "this" because main camera is a child of shape manager and the "this" is attched to main camera
        
    }
}
