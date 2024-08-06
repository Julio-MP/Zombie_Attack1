using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Zombie_Generator : MonoBehaviour
{

    public GameObject Zombies;
    private float count_Time = 0;
    public float Zumbi_Time =2;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count_Time += Time.deltaTime;
        if(count_Time >= Zumbi_Time){
            Instantiate(Zombies, transform.position, transform.rotation);
            count_Time = 0;
        }
        
    }
        

}

