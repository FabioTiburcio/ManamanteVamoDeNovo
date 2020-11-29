using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSleep : MonoBehaviour
{
    public DayCycleController dayCycleController;
    public FakeLoading fakeLoading;

    public void Sleep()
    {
        fakeLoading.Fade();
        dayCycleController.daySpeed *= 80;
        StartCoroutine(ResetDaySpeed());
    }

    IEnumerator ResetDaySpeed()
    {
        yield return new WaitForSeconds(5f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Sleep();
            }
        }
    }
}
