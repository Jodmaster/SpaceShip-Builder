using UnityEngine;

public class camera_zoom : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float zoomSpeed = 1.0f;
    public float minZoom = 1.0f;
    public float maxZoom = 5.0f;

    public game_manager manager;

    private Camera mainCamera;
    private Vector2 zoomCenter;

    void Start() {
        mainCamera = Camera.main;
        zoomCenter = Vector2.zero; // You can set this to your desired initial zoom center position.
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
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the zoom ratio
        float zoomRatio = newZoom / mainCamera.orthographicSize;

        //calculates the new position that the camera should move to 
        Vector2 goalPos = new Vector2(mainCamera.transform.position.x + mouseWorldPosition.x, mainCamera.transform.position.y + mouseWorldPosition.y);

        // Calculate the new position of the camera to keep the zoom centered on the mouse position
        Vector2 newPosition = Vector2.Lerp(mainCamera.transform.position, zoomCenter + (goalPos) * zoomRatio, 1 - zoomRatio);

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

        //moves the camera - speed of this is based on the camera size meaning the camera moves faster at larger sizes 
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * mainCamera.orthographicSize/2 * Time.deltaTime;
        transform.Translate(movement);
     
    }
}

