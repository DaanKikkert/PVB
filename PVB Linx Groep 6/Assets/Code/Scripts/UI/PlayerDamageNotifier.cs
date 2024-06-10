using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerDamageNotifier : MonoBehaviour
{
    [SerializeField] private Text playerDamageText;
    [SerializeField] private Image bloodSplatterImg;
    [SerializeField] private float delayBetweenNotifierPlayer;
    
    private bool notifierIsTurnedOnPlayer;

    private void Start()
    {
        notifierIsTurnedOnPlayer = false;
    }
    
    private IEnumerator DamageNotifierTimer()
    {
        if (notifierIsTurnedOnPlayer == false)
        {
            notifierIsTurnedOnPlayer = true;
            playerDamageText.gameObject.SetActive(true);
            bloodSplatterImg.gameObject.SetActive(true);
            yield return new WaitForSeconds(delayBetweenNotifierPlayer);
            playerDamageText.gameObject.SetActive(false);
            bloodSplatterImg.gameObject.SetActive(false);
            notifierIsTurnedOnPlayer = false;
        }
    }
    public void ShowDamageNotifier()
    {
        StartCoroutine(DamageNotifierTimer());
    }
}
