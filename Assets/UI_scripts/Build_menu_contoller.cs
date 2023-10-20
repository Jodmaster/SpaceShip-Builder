using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build_menu_contoller : MonoBehaviour
{
    private game_manager manager;
    public Image build_menu;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<game_manager>();
        build_menu = GetComponent<Image>();

        build_menu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.selected != null){
            build_menu.enabled = true;
        } else {
            build_menu.enabled = false;
        }
    }
}
