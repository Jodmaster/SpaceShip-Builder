using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class text_control : MonoBehaviour
{
    private game_manager manager;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<game_manager>();
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.selected == null)
        {
            canvas.enabled = false;
        } else
        {
            canvas.enabled = true;
        }
    }
}
