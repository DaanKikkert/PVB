using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class P_DamageNotifier : MonoBehaviour
{
    [SerializeField] private Text p_DamageText;
    [SerializeField] private float delayBetweenNotifier_P;
    
    private bool notifierIsTurnedOn_P;

    private void Start()
    {
        notifierIsTurnedOn_P = false;
    }

    
    private IEnumerator DamageNotifierTimer()
    {
        if (notifierIsTurnedOn_P == false)
        {
            notifierIsTurnedOn_P = true;
            p_DamageText.gameObject.SetActive(true);
            yield return new WaitForSeconds(delayBetweenNotifier_P);
            p_DamageText.gameObject.SetActive(false);
            notifierIsTurnedOn_P = false;
        }
    }
    public void ShowDamageNotifier()
    {
        StartCoroutine(DamageNotifierTimer());
        Debug.Log("ur mum");
    }
}
