using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class FadeEffect : MonoBehaviour
{
    public static IEnumerator FadeIn(CanvasGroup image, float duration)
    {
        bool isFinished = false;
        image.alpha = 0; 
        float tick = 1 / duration;
        while (!isFinished)
        {
            image.alpha += tick * Time.deltaTime;
            yield return new WaitForSeconds(tick * Time.deltaTime);
            if (image.alpha >= 1)
                isFinished = true;
        }
    }
    
    public static IEnumerator FadeOut(CanvasGroup image, float duration)
    {
        bool isFinished = false;
        image.alpha = 1;
        float tick = 1 / duration;
        while (!isFinished)
        {
            image.alpha -= tick * Time.deltaTime;
            yield return new WaitForSeconds(tick * Time.deltaTime);
            if (image.alpha <= 0)
                isFinished = true;
                
        }
        
    }
}
