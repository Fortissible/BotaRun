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

    public void ActivitiesCleared(string item_name)
    {
        if (taskTypes == TaskTypes.Activities && item_name == item_required){
            currentAmount++;
        }
    }
}

public enum TaskTypes
{
    Gathering,
    Activities
}