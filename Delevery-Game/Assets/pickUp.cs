using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    //public List<Vector3> dropdownPositions =new List<Vector3>();
    //public DeleveryManager manager;
    
    public Vector3 delveryPosition;
    private void OnTriggerEnter(Collider other)
    {
        //DeleveryManager.CurrentTaskIsDone = true;
        if (other.gameObject.tag == "Player")
        {
            DeleveryManager.pickedup = true;

            Destroy(gameObject);
        }
    }
}



