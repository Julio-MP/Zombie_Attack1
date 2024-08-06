using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Control : MonoBehaviour
{
    public float speedZ = 6;
    public GameObject Player;
    private Rigidbody rigidbodyPlayer;
    private Animator animatorPlayer; 


    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        animatorPlayer = GetComponent<Animator>();
        rigidbodyPlayer = GetComponent<Rigidbody>();
        
    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        Vector3 direction = Player.transform.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(direction);
        rigidbodyPlayer.MoveRotation(newRotation);

        if (distance > 3.0)
        {
            rigidbodyPlayer.MovePosition(
                rigidbodyPlayer.position +
                direction.normalized * speedZ * Time.deltaTime);

            animatorPlayer.SetBool("Atacando", false);
        }
        else
        {
            animatorPlayer.SetBool("Atacando", true);
        }

    }
    void Attacks_Player()
    {
        Time.timeScale = 0;
        Player.GetComponent<Control_Player>().GameOver_Text.SetActive(true);
        Player.GetComponent<Control_Player>().lived = false;
    }
}
