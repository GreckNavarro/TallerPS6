using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] int velocity;
    Rigidbody2D myRB;

    Vector2 AIM;
    Vector2 Movimiento;





    [SerializeField] private float timeStunned;
    [SerializeField] private float currentTime;


    private void OnEnable()
    {
        StatusPlayer.onStunned += PlayerStun;
    }
    private void OnDisable()
    {
        StatusPlayer.onStunned -= PlayerStun;
    }



    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        currentTime = timeStunned;
    }

    void Update()
    {

    }

    public void Aim(InputAction.CallbackContext value)
    {
        AIM = value.ReadValue<Vector2>();
    }

    public void Shoot(InputAction.CallbackContext value)
    {

        if (value.started)
        {
            Vector3 direccionMouse = Camera.main.ScreenToWorldPoint(AIM);
            Movimiento = direccionMouse - transform.position;
            myRB.velocity = Movimiento * velocity;
        }

    }


  

    private void PlayerStun()
    {
        StartCoroutine(PlayerStunned());
    }



    IEnumerator PlayerStunned()
    {
        velocity = 0;
        Movimiento = Vector2.zero;
        myRB.velocity = Movimiento;
       
        yield return new WaitForSeconds(timeStunned);
        velocity = 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
