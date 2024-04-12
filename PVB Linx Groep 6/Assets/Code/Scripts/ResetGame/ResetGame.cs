using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Code.Scripts
{
    public class ResetGame : MonoBehaviour
    {
        
        [SerializeField] private UnityEvent onReset;
        [SerializeField] private CanvasGroup image;
        [SerializeField] private float time;
        [SerializeField] private UniversalHealth baseHealth;
        private bool _isResseting = false;
        public void ResetTheGame()
        {
            if (!_isResseting)
            {
                StartCoroutine(ResetWithDelay());
            }
        }

        public IEnumerator ResetWithDelay()
        {
            _isResseting = true;
            baseHealth.gameObject.SetActive(false); 
            yield return StartCoroutine(FadeEffect.FadeIn(image, time/2));
            if (WaveManager.instance != null)
            {
                WaveManager.instance.ClearWave(1);
            }
            
            baseHealth.gameObject.SetActive(true); 
           //BASEHEALTH DOESN'T HAVE A SETTER. HOTFIX REQUIRED.
            baseHealth.HealHealth(20000);
            onReset.Invoke();
            yield return StartCoroutine(FadeEffect.FadeOut(image, time/2));
            _isResseting = false;

        }
    }
}