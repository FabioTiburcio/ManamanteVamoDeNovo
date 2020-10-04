using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeLoading : MonoBehaviour
{

    public bool faded = false;

    public float duration = 0.4f;

    CanvasGroup fakeLoadingGroup;

    public float faddingTime;

    public PlayerMovement playerMovScript;

    public void Fade()
    {
        fakeLoadingGroup = GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(fakeLoadingGroup, fakeLoadingGroup.alpha, faded ? 0 : 1));
        StartCoroutine(TimeToFadeOut(faddingTime));
        playerMovScript.freezePlayer = true;
    }

    public IEnumerator DoFade(CanvasGroup canvasGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / duration);

            yield return null;
        }
        faded = !faded;
    }

    public IEnumerator TimeToFadeOut(float faddingTime)
    {
        float counter = 0f;

        while(counter < faddingTime)
        {
            counter += Time.deltaTime;

            yield return null;
        }
        StartCoroutine(DoFade(fakeLoadingGroup, fakeLoadingGroup.alpha, faded ? 0 : 1));
        playerMovScript.freezePlayer = false;
    }
}
