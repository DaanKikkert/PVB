using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DamageNotifier : MonoBehaviour
{
    [SerializeField] private Text p_DamageText;
    [SerializeField] private Text c_DamageText;
    [SerializeField] private float delayBetweenNotifier_C;
    [SerializeField] private float delayBetweenNotifier_P;

    private bool notifierIsTurnedOn_C;
    private bool notifierIsTurnedOn_P;

    private void Start()
    {
        notifierIsTurnedOn_C = false;
        notifierIsTurnedOn_P = false;
    }

    public void ShowDamageNotifier()
    {
        DamageNotifierTimer();
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

        if (notifierIsTurnedOn_P == false)
        {
            notifierIsTurnedOn_P = true;
            p_DamageText.gameObject.SetActive(true);
            yield return new WaitForSeconds(delayBetweenNotifier_P);
            p_DamageText.gameObject.SetActive(false);
            notifierIsTurnedOn_P = false;
        }
    }
}
