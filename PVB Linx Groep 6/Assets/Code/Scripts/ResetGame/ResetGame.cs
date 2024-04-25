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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResetTheGame();
            }
        }

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
            baseHealth.gameObject.SetActive(true);
            if (WaveManager.instance != null)
                WaveManager.instance.ClearWave(1);
            baseHealth.SetCurrentHealt(baseHealth.GetMaxHealth());
            onReset.Invoke();
            yield return StartCoroutine(FadeEffect.FadeOut(image, time/2));
            _isResseting = false;

        }
    }
}