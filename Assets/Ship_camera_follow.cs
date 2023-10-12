using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_camera_follow : MonoBehaviour
{
    public GameObject follow_target;
    public Camera shipCamera;
    
    public float camera_height;
    public float zoomSpeed = 2f;
    public float minZoom = 1.0f;
    public float maxZoom = 20f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(follow_target.transform.position.x, follow_target.transform.position.y, camera_height);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(follow_target.transform.position.x, follow_target.transform.position.y, camera_height);

        // Get the mouse scroll wheel input
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");

        // Calculate the new zoom level
        float newZoom = shipCamera.orthographicSize - zoomInput * zoomSpeed;

        // Clamp the zoom level to the min and max values
        newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);

        shipCamera.orthographicSize = newZoom;
    }
}
