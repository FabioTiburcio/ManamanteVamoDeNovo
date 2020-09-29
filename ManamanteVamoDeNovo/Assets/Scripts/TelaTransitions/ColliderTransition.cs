using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTransition : MonoBehaviour
{
    public bool playerCollided;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerCollided = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerCollided = false;
    }
}
