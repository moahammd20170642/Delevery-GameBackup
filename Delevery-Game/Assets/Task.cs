using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public Vector3 PickUpPosition;
    public Vector3 DropDownPosition;
    public int rewardedCoins;
    public int taskDuration;


  public  Task( Vector3 PickUp ,Vector3 Dropdown  , int rewarded , int duration )
    {
        PickUpPosition = PickUp;
        DropDownPosition = Dropdown;
        rewardedCoins = rewarded;
        taskDuration = duration;

    }


}
