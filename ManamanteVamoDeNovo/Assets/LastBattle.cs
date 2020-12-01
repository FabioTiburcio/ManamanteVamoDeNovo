using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBattle : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("QuestAccepted") == 29)
        {
            boxCollider2D.enabled = true;
        }
    }
}
