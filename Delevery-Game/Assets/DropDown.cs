using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DeleveryManager.CurrentTaskIsDone = true;
            DeleveryManager.ordersconter++;
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if (DeleveryManager.TaskFaild == true) {

            DeleveryManager.TaskFaild = false;
            Destroy(gameObject);
        }
    }


    
}
