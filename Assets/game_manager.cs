using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public Camera main_cam;
    public Camera ship_cam;

    public Camera activeCam;

    public GameObject selected;

    public bool in_build_mode;
    
    // Start is called before the first frame update
    void Start()
    {
        main_cam.enabled = true;
        ship_cam.enabled = false;

        in_build_mode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !in_build_mode) {

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
            
            } 
        }

        if(selected != null) {
            if (Input.GetKeyDown(KeyCode.Escape) && !in_build_mode) {
                selected = null;
                changeCams();
            }
        }

        //switch to build mode
        if (Input.GetKeyDown(KeyCode.F)){
            switchBuildMode();
        }

       
    }

    //responsible for changing between the main cam and the ship cam
    void changeCams() {
        if (selected != null)
        {
            ship_cam.enabled = true;
            main_cam.enabled = false;
            
        }
        else
        {
            main_cam.enabled = true;
            ship_cam.enabled = false;
            
        }
    }

    //returns the currently selected cam 
    public Camera selectedCam() {

        if(main_cam.enabled == true) {
            activeCam = main_cam;
        } else {
            activeCam = ship_cam;
        }

        return activeCam;
    }

    public void switchBuildMode()
    {
        if(selected != null && !in_build_mode)
        {
            in_build_mode = true;
        } else
        {
            in_build_mode = false;
        }
    }
}
