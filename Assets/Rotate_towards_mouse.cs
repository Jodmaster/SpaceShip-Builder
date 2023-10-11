using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_towards_mouse : MonoBehaviour
{
    // Speed at which the object rotates towards the mouse
    public float rotationSpeed = 5f;

    void Update() {
        Rotate();
    }

    void Rotate() {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world coordinates
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the direction from the object to the mouse
        Vector3 directionToMouse = mouseWorldPosition - transform.position;

        // Calculate the angle between the object's forward vector and the direction to the mouse
        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

        // Create a rotation quaternion based on the angle
        Quaternion rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        // Rotate the object towards the mouse over time
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}

