using UnityEngine;

public class camera_zoom : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float zoomSpeed = 1.0f;
    public float minZoom = 1.0f;
    public float maxZoom = 5.0f;

    public game_manager manager;

    private Camera mainCamera;
    private Vector3 zoomCenter;

    void Start() {
        mainCamera = Camera.main;
        zoomCenter = Vector3.zero; // You can set this to your desired initial zoom center position.
        manager = FindObjectOfType<game_manager>(); 
    }

    void Update() {
        // Get the mouse scroll wheel input
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");

        // Calculate the new zoom level
        float newZoom = mainCamera.orthographicSize - zoomInput * zoomSpeed;

        // Clamp the zoom level to the min and max values
        newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);

        // Calculate the mouse position in world coordinates
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the zoom ratio
        float zoomRatio = newZoom / mainCamera.orthographicSize;

        // Calculate the new position of the camera to keep the zoom centered on the mouse position
        Vector3 newPosition = Vector3.Lerp(mainCamera.transform.position, zoomCenter + (mainCamera.transform.position + mouseWorldPosition) * zoomRatio, 1 - zoomRatio);

        // Update the camera's orthographic size and position
        mainCamera.orthographicSize = newZoom;
        mainCamera.transform.position = newPosition;

        if(manager.selected == null) {
            Camera_Movement();
        }
    }

    private void Camera_Movement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
     
    }
}

