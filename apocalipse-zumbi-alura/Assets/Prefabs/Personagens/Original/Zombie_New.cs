using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_New : MonoBehaviour
{
    public GameObject Player;
    public float speedZ = 6;
    public GameObject GameOver_Text;


    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        Vector3 direction = Player.transform.position - transform.position;
        //Quaternion = rota��o, LookRotation fala para onde o corpo rigido tem que rotacionar em rela��o a outro objeto
        Quaternion newRotation = Quaternion.LookRotation(direction);
        GetComponent<Rigidbody>().MoveRotation(newRotation);

        if (distance > 2.5)
        {
            GetComponent<Rigidbody>().MovePosition
                (GetComponent<Rigidbody>().position +
                direction.normalized * speedZ * Time.deltaTime);

            GetComponent<Animator>().SetBool("Atacando", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Atacando", true);
        }

    }
    void Attacks_Player()
    {
        Time.timeScale = 0;
        GameOver_Text.SetActive(true);
        Player.GetComponent<Control_Player>().lived = false;
    }
}
