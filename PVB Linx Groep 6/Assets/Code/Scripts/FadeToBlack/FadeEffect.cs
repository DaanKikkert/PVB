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
            Debug.Log("reppep");
            image.alpha -= tick * Time.deltaTime;
            yield return new WaitForSeconds(tick * Time.deltaTime);
            if (image.alpha <= 0)
            {
                isFinished = true;
                Debug.Log("peep");
            }
                
        }
        
    }
    
    
    // public static void FadeIn(CanvasGroup image, float duration)
    // {
    //     image.alpha = 0;
    //     
    //     while (!isFinished)
    //     {
    //         Debug.Log("STe");
    //         image.alpha += duration * Time.deltaTime;
    //         if (image.alpha >= 1)
    //             isFinished = true;
    //     }
    // }
    // public static void FadeOut(CanvasGroup image, float duration)
    // {
    //     image.alpha = 1;
    //     while( image.alpha > 0)
    //             image.alpha -= duration * Time.deltaTime;
    //     
    // }
    //
}