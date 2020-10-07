using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSystem : MonoBehaviour
{
    public GameObject[] thingsToRespawn;
    public Vector3[] positionToRespawn;
    public Transform[] thingsPosition;
    // Start is called before the first frame update
    void Start()
    {
        thingsPosition = new Transform[thingsToRespawn.Length];
        positionToRespawn = new Vector3[thingsPosition.Length];
        for (int i = 0; i < thingsToRespawn.Length; i++)
        {
            thingsPosition[i] = thingsToRespawn[i].transform;
            positionToRespawn[i] = thingsPosition[i].position;
        }
        
    }

    private void OnEnable()
    {
        for (int i = 0; i < thingsToRespawn.Length; i++)
        {
            if (!thingsToRespawn[i].activeSelf)
            {
                thingsToRespawn[i].transform.position = positionToRespawn[i];
                thingsToRespawn[i].SetActive(true);
            }
        }
    }
}
