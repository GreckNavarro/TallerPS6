using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatusPlayer : MonoBehaviour
{
    public static event Action onStunned;

    private void OnEnable()
    {
        Enemy.ActiveStun += CollisionFlower;
    }
    private void OnDisable()
    {
        Enemy.ActiveStun -= CollisionFlower;
    }

    private void CollisionFlower()
    {
        Debug.Log("Detectado Choco Player");
        onStunned?.Invoke();
    }





}
