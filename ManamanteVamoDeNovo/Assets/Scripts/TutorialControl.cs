using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class TutorialControl : MonoBehaviour
{
    public GameObject nextTip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(showButton());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator showButton()
    {
        yield return new WaitForSeconds(5f);
        nextTip.SetActive(true);
    }
}
