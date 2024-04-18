using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class MovementPlayer3D : MonoBehaviour
{
    Vector2 AIM;
    Vector3 Movimiento;
    [SerializeField] int velocity = 3;

    Rigidbody myRB;



    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Aim(InputAction.CallbackContext value)
    {
        AIM = value.ReadValue<Vector2>();

        Ray ray = Camera.main.ScreenPointToRay(value.ReadValue<Vector2>());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            AIM = new Vector2(hit.point.x, hit.point.z);
            Debug.Log(AIM);
        }
    }

    public void Shoot(InputAction.CallbackContext value)
    {

        if (value.started)
        {
            Vector3 direccionMouse = new Vector3(AIM.x, 0.5f, AIM.y);
            Movimiento = direccionMouse - transform.position;
            myRB.velocity = new Vector3(Movimiento.x * velocity, myRB.velocity.y, Movimiento.z * velocity);
        }

    }
}
