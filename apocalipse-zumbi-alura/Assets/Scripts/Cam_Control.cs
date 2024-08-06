using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Control : MonoBehaviour
{        
    public GameObject Player1;
    private Vector3 distance;
    void Start()
    {
        distance = transform.position - Player1.transform.position;
    }
    void Update()
    {
        transform.position  = Player1.transform.position + distance;
    }
}
