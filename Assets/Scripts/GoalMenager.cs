using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMenager : MonoBehaviour
{
    public static GoalMenager singleton;

    public int holyWaterNeeded;
    public int holyWaterCollect;
    public bool canEnter;

    public void Awake()
    {
        singleton = this;
    }
    
    public void CollectHolyWater()
    {
        holyWaterCollect++;
        if (holyWaterCollect >= holyWaterNeeded) 
        { 
            canEnter = true;
        }
    }
}
