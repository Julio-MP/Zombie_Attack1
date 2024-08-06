using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Control : MonoBehaviour
{
    public GameObject Bala;
    public GameObject Barrel_Gun_Empty;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bala, Barrel_Gun_Empty.transform.position, transform.rotation);
        }
    }
}
