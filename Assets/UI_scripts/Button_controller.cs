using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button_controller : MonoBehaviour
{

    private game_manager manager;
    public Image image;
    public Button button;

    public TMP_Text button_text;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<game_manager>();
        image = GetComponent<Image>(); 
        button = GetComponent<Button>();

        button_text = GetComponentInChildren<TMP_Text>();

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
            button_text.enabled = true;
        }
        else
        {
            image.enabled=false;
            button.enabled=false;
            button_text.enabled = false;
        }
    }
}
