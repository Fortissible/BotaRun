using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaskGoals
{
    public TaskTypes taskTypes;

    public int requiredAmount;
    public int currentAmount;

    public bool isReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void ItemGathered()
    {
        if (taskTypes == TaskTypes.Gathering)
            currentAmount++;
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