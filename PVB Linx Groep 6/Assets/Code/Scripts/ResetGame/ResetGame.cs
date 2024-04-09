using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.Scripts
{
    public class ResetGame : MonoBehaviour
    {
        [SerializeField] private CanvasGroup image;
        [SerializeField] private float time;
        [SerializeField] private GameObject Base;


        private void Awake()
        {
            StartCoroutine(ResetWithDelay());
        }

        public void ResetTheGame()
        {
            StartCoroutine(FadeEffect.FadeIn(image, time));
            //yield return new WaitForSeconds(time / 2);
            Instantiate(Base);
            if (WaveManager.instance != null)
            {
                WaveManager.instance.ClearWave(1);
            }
            StartCoroutine(FadeEffect.FadeOut(image, time));
        }

        public IEnumerator ResetWithDelay()
        {
            StartCoroutine(FadeEffect.FadeIn(image, time/2));
            yield return new WaitForSeconds(time / 2);
            Instantiate(Base);
            if (WaveManager.instance != null)
            {
                WaveManager.instance.ClearWave(1);
            }
            StartCoroutine(FadeEffect.FadeOut(image, time/2));
            
        }
    }
}
