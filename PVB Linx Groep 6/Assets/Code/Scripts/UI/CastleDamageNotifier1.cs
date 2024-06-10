using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CastleDamageNotifier : MonoBehaviour
{
    [SerializeField] private Text castleDamageText;
    [SerializeField] private float delayBetweenNotifierCastle;

    private bool notifierIsTurnedOnCastle;

    private void Start()
    {
        notifierIsTurnedOnCastle = false;
    }

    
    private IEnumerator DamageNotifierTimer()
    {
        if (notifierIsTurnedOnCastle == false)
        {
            notifierIsTurnedOnCastle = true;
            castleDamageText.gameObject.SetActive(true);
            yield return new WaitForSeconds(delayBetweenNotifierCastle);
            castleDamageText.gameObject.SetActive(false);
            notifierIsTurnedOnCastle = false;
        }
    }
    public void ShowDamageNotifier()
    {
        StartCoroutine(DamageNotifierTimer());
    }
}
