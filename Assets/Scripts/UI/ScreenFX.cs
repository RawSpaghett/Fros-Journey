using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class ScreenFX 
{
   public static void FadeOut()
   {
      host.StartCoroutine(FadeIn(fadeCanvas,1,0,duration));
   }

   public static void FadeIn(MonoBehaviour host,CanvasGroup fadeCanvas, float duration) //uses monobehaviour to determine whats using it because its a static script
   {
      host.StartCoroutine(FadeIn(fadeCanvas,0,1,duration));
   }

   private IEnumerator Fade(CanvasGroup fadeCanvas, float start , float end, float duration) //handles both in and out fading
   {
      float elapsed = 0;

      while (elapsed < duration)
      {
         elapsed += Time.deltaTime;
         fadeCanvas.alpha = Mathf.Lerp(start,end,elapsed/duration); //elapsed/duration is essentially the percentage of how done it is and finishes at 1
         yield return null;
      }
      fadeCanvas.alpha = end;
   }

}
