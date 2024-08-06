using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control_Player : MonoBehaviour
{
    Vector3 direction;
    public float speedP1 = 10;
    public LayerMask GroundMask;
    public GameObject GameOver_Text;
    public bool lived = true;
    private Rigidbody rigidbodyPlayer;
    private Animator animatorPlayer;


    private void Start()
    {
        Time.timeScale = 1;
        animatorPlayer = GetComponent<Animator>();
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");
        direction = new Vector3(eixoX, 0, eixoZ);
        if (direction != Vector3.zero)
        {
            animatorPlayer.SetBool("Moving", true);
        }
        else
        {
            animatorPlayer.SetBool("Moving", false);
        }

        if (lived == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Scene_1");
            }
        }
    }

    private void FixedUpdate()
    {
        rigidbodyPlayer.MovePosition(
            rigidbodyPlayer.position +
            (direction * speedP1 * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impact;

        if (Physics.Raycast(raio, out impact, 100, GroundMask))
        {
            Vector3 aiming_position = impact.point - transform.position;
            aiming_position.y = transform.position.y;
            Quaternion newRotation = Quaternion.LookRotation(aiming_position);
            rigidbodyPlayer.MoveRotation(newRotation);

        }
    }
}
