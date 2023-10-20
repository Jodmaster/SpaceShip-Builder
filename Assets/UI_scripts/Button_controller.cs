using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_controller : MonoBehaviour
{

    private game_manager manager;
    public Image image;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<game_manager>();
        image = GetComponent<Image>(); 
        button = GetComponent<Button>();

        image.enabled = false;
        button.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.selected != null)
        {
            image.enabled = true;
            button.enabled = true;
        }
        else
        {
            image.enabled=false;
            button.enabled=false;
        }
    }
}
