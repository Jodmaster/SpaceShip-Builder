using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Spawn_and_Drag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject prefabToSpawn;
    private GameObject currentSpawnedObject;
    private bool isDragging = false;
    private Vector2 offset;

    public void OnBeginDrag(PointerEventData eventData) {
        if (currentSpawnedObject != null) {
            offset = currentSpawnedObject.transform.position - (Vector3)eventData.position;    
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if (currentSpawnedObject != null) {
            currentSpawnedObject.transform.position = eventData.position + offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        currentSpawnedObject = null;
    }

    public void OnPointerDown(PointerEventData eventData) {
        if(currentSpawnedObject == null) {
            currentSpawnedObject = Instantiate(prefabToSpawn, eventData.position, Quaternion.identity);
            offset = currentSpawnedObject.transform.position - (Vector3)eventData.position;
        }
    }

}
