using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enter_build_mode : MonoBehaviour
{
    private game_manager manager;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<game_manager>();
        text = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if(manager.selected == null || manager.in_build_mode == true)
        {
            text.enabled = false;
        } else
        {
            text.enabled = true;
        }
    }
}
