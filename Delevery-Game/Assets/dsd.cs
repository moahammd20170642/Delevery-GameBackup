using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening ;
public class dsd : MonoBehaviour
{

    public Transform car;


    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        this.transform.DOLookAt(car.position, 0.5f);
    }
}
