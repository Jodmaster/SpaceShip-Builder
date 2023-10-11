using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_camera_follow : MonoBehaviour
{
    public GameObject follow_target;
    public float camera_height;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(follow_target.transform.position.x, follow_target.transform.position.y, camera_height);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(follow_target.transform.position.x, follow_target.transform.position.y, camera_height);
    }
}
