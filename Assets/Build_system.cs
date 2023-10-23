using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_system : MonoBehaviour
{
    public game_manager gameManager;
    public LayerMask snapLayer;
    public float snapDistance = 1.0f;

    private bool isSnapped = false;
    private Transform snapTarget;
    private Vector3 originalLocalPosition;
    private Quaternion originalLocalRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalLocalPosition = transform.localPosition;
        originalLocalPosition = transform.localPosition;

        gameManager = FindObjectOfType<game_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            TrySnapToNearestAttachmentPoint();
        } 

        if(Input.GetMouseButtonDown(0) && isSnapped) {
            MoveTogetherWithParent();
        }
    }

    private void MoveTogetherWithParent() {
        Vector3 mousePosition = gameManager.activeCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 offset = mousePosition - transform.position;

        transform.position = snapTarget.position + offset;
    }

    private void TrySnapToNearestAttachmentPoint() {
        Vector3 mousePosition = gameManager.activeCam.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(mousePosition, snapDistance, snapLayer);

        if(hitColliders.Length > 0) {
            float closestDistance = float.MaxValue;
            snapTarget = null;

            foreach(var collider in hitColliders) {
                AttachmentPoint attachmentPoint = collider.GetComponent<AttachmentPoint>();

                if(attachmentPoint != null) {
                    float distance = Vector2.Distance(mousePosition, attachmentPoint.transform.position);

                    if(distance < closestDistance) {
                        closestDistance = distance;
                        snapTarget = attachmentPoint.transform;
                    }
                }
            }

            if(snapTarget != null) {
                transform.position = snapTarget.position;
                transform.rotation = snapTarget.rotation;
            }
        }

        else {
            isSnapped = false;
            transform.localPosition = originalLocalPosition;
            transform.localRotation = originalLocalRotation;
        }
    }
}
