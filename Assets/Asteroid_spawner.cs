using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_spawner : MonoBehaviour
{

    public GameObject AsteroidPrefab;
    [SerializeField] int numberOfObjects = 100;
    [SerializeField] Vector2 spawnArea = new Vector2(10, 10);
    [SerializeField] Vector2 scaleRange = new Vector2(0.5f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfObjects; i++) {
            //Random position within the spawn area
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x, spawnArea.x),
                Random.Range(-spawnArea.y, spawnArea.y),
                5
             );

            //Random scale within the specified range
            float randomScaleX = Random.Range(scaleRange.x, scaleRange.y);
            float randomScaleY = Random.Range(scaleRange.x, scaleRange.y);

            float randomRot = Random.Range(0, 359);

            //creates a new instance of an asteroid and sets the scale
            GameObject Asteroid = Instantiate(AsteroidPrefab, randomPosition, Quaternion.identity);
            Asteroid.transform.localScale = new Vector3(randomScaleX, randomScaleY, 1);
            Asteroid.transform.localRotation = Quaternion.Euler(0, 0, randomRot);
        }
    }    
}
