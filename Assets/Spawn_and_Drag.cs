using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Spawn_and_Drag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public game_manager manager;
    public GameObject prefabToSpawn;
    private GameObject currentSpawnedObject;
    

    public void Start() {
        manager = FindObjectOfType<game_manager>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
      
    }

    public void OnDrag(PointerEventData eventData) {
        if (currentSpawnedObject != null) {
            //need to adjust the vector up the x axis to avoid annoying depth issues that .ScreenToWorldPoint seems to generate 
            Vector3 newPos = new Vector3(manager.activeCam.ScreenToWorldPoint(Input.mousePosition).x, manager.activeCam.ScreenToWorldPoint(Input.mousePosition).y, 2f);
            currentSpawnedObject.transform.position = newPos;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        currentSpawnedObject = null;
    }

    public void OnPointerDown(PointerEventData eventData) {
        if(currentSpawnedObject == null) {
            Vector3 spawnPos = new Vector3(eventData.position.x, eventData.position.y, 2f);
            currentSpawnedObject = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
        }
    }

}
