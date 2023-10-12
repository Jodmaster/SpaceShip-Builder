using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_movement : MonoBehaviour
{
    Rigidbody2D rigidBody;
    [SerializeField] GameObject pivot;

    
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float rotationInertia = 0.9f;

    private float currentRotationSpeed = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //Input handling
        if (Input.GetKey(KeyCode.W)) {rigidBody.AddForce(transform.up * moveSpeed, ForceMode2D.Force);}
        if (Input.GetKey(KeyCode.S)) {rigidBody.AddForce(-transform.up * moveSpeed, ForceMode2D.Force);}
            
        float rotationInput = Input.GetAxis("Horizontal");
        float desiredRotationSpeed = rotationInput * rotationSpeed;

        currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, desiredRotationSpeed, 1.0f - rotationInertia);

        transform.RotateAround(pivot.transform.position, Vector3.forward, -currentRotationSpeed * Time.deltaTime);
        
    }
}
