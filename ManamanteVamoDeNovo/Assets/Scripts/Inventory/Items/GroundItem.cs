using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour, ISerializationCallbackReceiver
{
    public ItemObject itemObject;

    public void OnAfterDeserialize()
    {
    }

    public void OnBeforeSerialize()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = itemObject.uiDisplay;
    }

    public void OnEnable()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = itemObject.uiDisplay;
    }
}
