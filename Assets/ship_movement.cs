using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_movement : MonoBehaviour
{
    Rigidbody2D rigidBody;
    [SerializeField] GameObject pivot;

    
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float rotationSpeed = 50f;
    
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
        if (Input.GetKey(KeyCode.A)) {transform.RotateAround(pivot.transform.position, new Vector3(0,0,1) ,Time.deltaTime * rotationSpeed);}
        if (Input.GetKey(KeyCode.D)) {transform.RotateAround(pivot.transform.position, new Vector3(0, 0, -1), Time.deltaTime * rotationSpeed);}
    }
}
