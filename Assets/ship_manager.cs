using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_manager : MonoBehaviour
{

    public bool isSelected;
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
    }

    private void checkSelected() {
        if (manager.selected == this) {
            isSelected = true;
        }
        else {
            isSelected = false;
        }
    }

    
}
