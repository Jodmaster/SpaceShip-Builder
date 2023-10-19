using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline_ship : MonoBehaviour
{

    private ship_manager manager;

    [SerializeField] SpriteRenderer outlineSprite;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponentInParent<ship_manager>();
        outlineSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (manager.isSelected) {
            outlineSprite.enabled = true;
        } else {
            outlineSprite.enabled = false;
        }
    }
}
