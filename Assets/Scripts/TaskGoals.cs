using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaskGoals
{
    public TaskTypes taskTypes;
    public int requiredAmount;
    public int currentAmount;
    public string item_required;

    public bool isReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void ItemGathered(string item_name)
    {
        if (taskTypes == TaskTypes.Gathering && item_required == item_name)
        {
            currentAmount++;
        }
    }

    public void ActivitiesCleared()
    {
        if (taskTypes == TaskTypes.Activities)
            currentAmount++;
    }
}

public enum TaskTypes
{
    Gathering,
    Activities
}