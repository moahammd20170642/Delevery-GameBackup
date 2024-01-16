using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ArrowController : MonoBehaviour
{
 DeleveryManager manager;
   public  Vector3 targetObject;
    //p/*ublic Transform car;*/
    private void Awake()
    {
        manager = GameObject.Find("Delevery manager").GetComponent<DeleveryManager>();
    }
    void Update()
    {
             targetObject = manager.targetObject;
            this.transform.DOLookAt(targetObject, 0.5f);
         
    }
}
