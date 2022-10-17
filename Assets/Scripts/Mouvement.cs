using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    ControllerInput Controller;
    Rigidbody rb;
    float movement;
    public float speed;
    Animator anim;
    public bool negative;
    private bool run = false;


    private void Awake()
    {

        Controller = new ControllerInput();
        rb = GetComponent<Rigidbody>();

    }

    private void OnEnable()
    {
        Controller.Enable();
    }

    public void OnDisable()
    {
        Controller.Disable();
    }

    private void FixedUpdate()
    {


        movement = Controller._2DGame.Movement.ReadValue<float>();
        if (movement != 0)
        {

            if (movement <= -0.1)
            {
                negative = true;
                run = true;
                transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                anim.SetFloat("Speed", run ? 5 : 3);
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
            if (movement >= 0.1)
            {
                negative = false;
                run = true;
                transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                anim.SetFloat("Speed", run ? 5 : 3);
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
        }
        else
        {
            run = false;
            anim.SetFloat("Speed", 0);
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }
}
