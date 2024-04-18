using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public static Action ActiveStun;
    private SpriteRenderer sp;

    private void OnEnable()
    {
        StatusPlayer.onStunned += ChangeColorEvent;
    }

    private void OnDisable()
    {
        StatusPlayer.onStunned -= ChangeColorEvent;
    }
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ActiveStun?.Invoke();
            Destroy(gameObject);
        }
        
    }

    public void ChangeColorEvent()
    {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        sp.color = Color.green;
        yield return new WaitForSeconds(3f);
        sp.color = Color.red;
    }
}
