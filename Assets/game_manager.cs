using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public Camera main_cam;
    public Camera ship_cam;

    public GameObject selected;
    
    // Start is called before the first frame update
    void Start()
    {
        main_cam.enabled = true;
        ship_cam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            //Cast a ray from the camera to the mouse position
            Ray ray = main_cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            //check for hit
            if (hit.collider != null) {
                
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject != selected) {
                    selected = hitObject;
                    changeCams();
                }
            
            } else {
                selected = null;
                changeCams();
            }
        }
    }

    void changeCams() {
        if(selected != null) {
            main_cam.enabled = false;
            ship_cam.enabled = true;
            Debug.Log("Main cam is: " + Camera.main);
        } else {
            ship_cam.enabled = false;
            main_cam.enabled = true;
            Debug.Log("Main cam is: " + Camera.main);
        }
    }
}
