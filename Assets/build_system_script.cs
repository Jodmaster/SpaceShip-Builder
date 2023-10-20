using UnityEngine;

public class ModularBuildSystem : MonoBehaviour
{
    public LayerMask snapLayer; // Define the layer where your modular pieces are placed.
    public float snapDistance = 0.1f; // The snap distance to consider two pieces as connected.

    private bool isSnapped = false;
    private Transform snapTarget;
    private Vector3 originalLocalPosition;
    private Quaternion originalLocalRotation;

    private void Start()
    {
        originalLocalPosition = transform.localPosition;
        originalLocalRotation = transform.localRotation;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TrySnapToNearestAttachmentPoint();
        }

        if (Input.GetMouseButton(0) && isSnapped)
        {
            MoveTogetherWithParent();
        }
    }

    void TrySnapToNearestAttachmentPoint()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(mousePosition, snapDistance, snapLayer);

        if (hitColliders.Length > 0)
        {
            float closestDistance = float.MaxValue;
            snapTarget = null;

            foreach (var collider in hitColliders)
            {
                AttachmentPoint attachmentPoint = collider.GetComponent<AttachmentPoint>();
                if (attachmentPoint != null)
                {
                    float distance = Vector2.Distance(mousePosition, attachmentPoint.transform.position);

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        snapTarget = attachmentPoint.transform;
                    }
                }
            }

            if (snapTarget != null)
            {
                // Snap and align at the attachment point's origin.
                transform.position = snapTarget.position;
                transform.rotation = snapTarget.rotation;
                isSnapped = true;
            }
        }
        else
        {
            isSnapped = false;
            transform.localPosition = originalLocalPosition;
            transform.localRotation = originalLocalRotation;
        }
    }

    void MoveTogetherWithParent()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 offset = mousePosition - transform.position;

        transform.position = snapTarget.position + offset;
    }
}
