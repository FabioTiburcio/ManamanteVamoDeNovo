using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;
    public string goalTag;

    public bool IsReached()
    {
        Debug.Log(currentAmount >= requiredAmount);
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled()
    {
        Debug.Log("TO AQUI");
                currentAmount++;
    }

    public void ItemGathered()
    {
        currentAmount++;
    }

    public void ItemCrafted()
    {
        currentAmount++;
    }

}

public enum GoalType
{
    Kill,
    Gathering,
    Crafting
}
