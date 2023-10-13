using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_manager : MonoBehaviour
{

    public bool isSelected;
    public bool isBuilding;
    
    BoxCollider2D boxCollider;
    game_manager manager;


    // Start is called before the first frame update
    void Start() {
        isSelected = false;
        boxCollider = GetComponent<BoxCollider2D>();
        manager = FindObjectOfType<game_manager>();
    }

    // Update is called once per frame
    void Update() {
        checkSelected();
        checkInBuild();
    }

    public void checkInBuild()
    {
        if (manager.in_build_mode)
        {
            isBuilding = true;
        } else
        {
            isBuilding = false;
        }
    }

    public void checkSelected() {
        if (manager.selected == gameObject) {
            isSelected = true;
        }
        else {
            isSelected = false;
        }
    }

    
}
