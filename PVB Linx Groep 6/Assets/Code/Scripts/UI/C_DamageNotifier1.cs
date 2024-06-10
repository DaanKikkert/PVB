using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class C_DamageNotifier : MonoBehaviour
{
    [SerializeField] private Text c_DamageText;
    [SerializeField] private float delayBetweenNotifier_C;

    private bool notifierIsTurnedOn_C;

    private void Start()
    {
        notifierIsTurnedOn_C = false;
    }

    
    private IEnumerator DamageNotifierTimer()
    {
        if (notifierIsTurnedOn_C == false)
        {
            notifierIsTurnedOn_C = true;
            c_DamageText.gameObject.SetActive(true);
            yield return new WaitForSeconds(delayBetweenNotifier_C);
            c_DamageText.gameObject.SetActive(false);
            notifierIsTurnedOn_C = false;
        }
    }
    public void ShowDamageNotifier()
    {
        StartCoroutine(DamageNotifierTimer());
        Debug.Log("ur mum");
    }
}
