using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] Text texto;
    void Start()
    {
        texto.text = "";
    }

    private void OnEnable()
    {
        StatusPlayer.onStunned += ChangeUI;
    }

    private void OnDisable()
    {
        StatusPlayer.onStunned -= ChangeUI;
    }

    public void ChangeUI()
    {
        StartCoroutine(ChangeText());
    }
    IEnumerator ChangeText()
    {
        texto.text = "STUNNED";
        yield return new WaitForSeconds(3f);
        texto.text = "";
    }
}

