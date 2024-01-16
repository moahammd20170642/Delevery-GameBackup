using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour

{
   
    public List <GameObject> pickUpObjects=new List<GameObject>();
    public List<GameObject> DropdownObjects = new List<GameObject>();

   
    public  List<Vector3> PicKUpLocations = new List<Vector3>();
    public   List<Vector3> DropdownLocations =new List<Vector3>();

    public List<int> Duration=new List<int>();
    public List<int> Coins =new List<int>();


 
    public void fill()
    {
       
        //Coins.Clear();
        //Duration.Clear();

        Coins.Add(10);
        Coins.Add(15);
        Coins.Add(15);
        Coins.Add(16);
        Coins.Add(18);
        Coins.Add (19);
        Coins.Add(20);
        Coins.Add(21);

        Duration.Add(7);
        Duration.Add(15);
        Duration.Add(15);
        Duration.Add(13);
        Duration.Add(12);
        Duration.Add(11);
        Duration.Add(22);
        Duration.Add(21);

        foreach (var item in pickUpObjects)
        {
            PicKUpLocations.Add(item.transform.position);
            Destroy(item);

        }

        foreach (var item in DropdownObjects)
        {
            DropdownLocations.Add(item.transform.position);
            Destroy(item);
        }

      







        pickUpObjects.Clear();
        DropdownObjects.Clear();
        //Coins.Clear();
        //Duration.Clear();

        
    }

}
