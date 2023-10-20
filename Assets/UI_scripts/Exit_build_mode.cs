using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Exit_build_mode : MonoBehaviour
{
    private game_manager manager;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<game_manager>();
        text = GetComponent<TMP_Text>();

        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.in_build_mode) {
            text.enabled = true;
        } else {
            text.enabled = false;
        }
    }
}
