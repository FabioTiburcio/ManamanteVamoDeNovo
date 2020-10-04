using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSlotCreator : MonoBehaviour
{
    public GameObject infoSlotPrefab;
    public GameObject[] pages;
    public int xStart;
    public int yStart;
    public int xSpaceBetweenItem;
    public int ySpaceBetweenItem;
    public int numberOfCollums;
    public void CreateSlots()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            var obj = Instantiate(infoSlotPrefab, Vector3.zero, Quaternion.identity, transform);
            var obj1 = Instantiate(infoSlotPrefab, Vector3.zero, Quaternion.identity, transform);
            var obj2 = Instantiate(infoSlotPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj1.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj2.GetComponent<RectTransform>().localPosition = GetPosition(i);
        }
    }
    private Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (xSpaceBetweenItem * (i % numberOfCollums)), yStart + (-ySpaceBetweenItem * (i / numberOfCollums)), 0f);
    }
}
