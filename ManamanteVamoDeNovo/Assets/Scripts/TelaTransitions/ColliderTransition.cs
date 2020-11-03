using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTransition : MonoBehaviour
{
    public Transitions transitions;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") transitions.SaidaUsada(this.name);
    }
}
