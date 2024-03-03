using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;
using SIS;

public class DeleveryManager : MonoBehaviour
   {
    public bool timeUP;
    public bool taskStarted = false;
    public static bool TaskFaild = false;
    public CanvasGroup timeText;
  public bool isdrifting =false;
    public AudioManager AudioManager;
    public UIManager UIManager;
    public Transform car;
    public DataManager dataManager;
    public GameObject arrow;
    public  Vector3 targetObject;
    public float rotationSpeed =5.0f;
    public static int ordersconter =0 ;
    public int coins = 0;
    public TextMeshProUGUI ordeCounterText;
    public TextMeshProUGUI coinsText;

    public TimeManager timeManager;
    public GameObject deleveryarea;
    public GameObject dropdowm;   
    public static bool CurrentTaskIsDone = false;
    public static bool pickedup = false;
    public  int currentTaskIndex = 0;
    public int TotalCoins;
    public List<GameObject>cars = new List<GameObject>();
    public List<GameObject> foodPrefab = new List<GameObject>();
    //List<Vector3> positionsList = new List<Vector3>();
    //List<Vector3> dropdownPositions =new List<Vector3>();
    public int doubledCoins;
    List<Task> tasks = new List<Task>();
    // Start is called before the first frame update
   int taskcounter =1 ;
    //public AddSystem addSystem;
    public TextMeshProUGUI grantedcoins;
    public RectTransform gameover;
    public Button playAddButton;
    public TextMeshProUGUI PlusText;



   
    
    void Start()
    {
          //TaskFaild = false;
         timeText.alpha = 0.0f;
        // foreach (GameObject car in cars) { 
        //   car.SetActive(false);    
        //}
       
        Instantiate(cars[PlayerPrefs.GetInt(prefs.SelectedCar, 0)], new Vector3(63f, 1.07000732f, 0.600000024f), transform.rotation);
        pickedup = false;
        CurrentTaskIsDone = false;
        ordersconter = 0;
        TotalCoins = PlayerPrefs.GetInt(prefs.coins, 0);

        dataManager.fill();
        FillData();     
        CreatNewTask();
    }




    

    public void FillData()
    {
       int DataCount =dataManager.PicKUpLocations.Count;
        for (int i = 0; i < DataCount; i++)
        {
            
            Task task =new Task(dataManager.PicKUpLocations[i] , dataManager.DropdownLocations[i] , dataManager.Coins[i] , dataManager.Duration[i]);
            tasks.Add(task);    
            
        }

        tasks.Shuffle();
        

    }
    //void SelectRandomItem()
    //{
    //    if (tasks.Count > 1)
    //    {
    //        int randomIndex = Random.Range(0, tasks.Count);
    //        Task randomItem = tasks[randomIndex];

    //        Debug.Log("Randomly selected item: " + randomItem);

    //        // If you want to remove the selected item from the list to prevent repetition
    //        tasks.RemoveAt(randomIndex);

    //    }
    //    else
    //    {
    //        dataManager.fill();
    //        SelectRandomItem();
    //    }
    //}


    public void  GameOver()
    {
        gameover.anchoredPosition = new Vector3(0,0,0);
    }
    public void rewardAddUI()
    {
        //coins = coins * 2;

        //addSystem.ShowRewardedAd(coins);

        playAddButton.gameObject.SetActive(false);

    }
    public void MakeItHarder()
    {
        foreach(var task in tasks)
        {
            task.taskDuration -= 1;
        }

        //tasks.

    }
    private void Update()
    {

        if (isdrifting)
        {
            //timeManager.currentTime += 0.05f;
            Debug.Log("Drift");

            isdrifting = false;
        }

        //if (timeManager.currentTime <= 0)
        //{
        //    CreatNewTask();
        //}
        ordeCounterText.text=ordersconter.ToString();
        coinsText.text=coins.ToString();
        grantedcoins.text=coins.ToString();
   
        if (CurrentTaskIsDone&& currentTaskIndex+1 <= tasks.Count)
        {
            taskStarted = false;
            Debug.Log("mmmmmmmmmm");
             timeText.alpha = 0;
            coins += tasks[currentTaskIndex].rewardedCoins;
            TotalCoins += tasks[currentTaskIndex].rewardedCoins;
               PlayerPrefs.SetInt(prefs.coins, TotalCoins);
             DBManager.AddCurrency("coins", tasks[currentTaskIndex].rewardedCoins);
            //timeManager.currentTime += tasks[currentTaskIndex].taskDuration;
            AudioManager.playdropdown();
            UIManager.ActivateTaskUI(tasks[currentTaskIndex].rewardedCoins, tasks[currentTaskIndex].taskDuration);
            currentTaskIndex++;

            CreatNewTask();
            CurrentTaskIsDone = false;
           
        }

        if ( taskStarted && timeManager.currentTime <1 )
        {
            TaskFaild = true;
            timeIsUp();
           taskStarted = false;   

        }


        if (pickedup == true )
        {

            taskStarted= true; ;
            timeText.alpha = 1.0f;
            timeManager.totalTime = tasks[currentTaskIndex].taskDuration;
            timeManager.currentTime = timeManager.totalTime;

            //timeManager.currentTime += tasks[currentTaskIndex].taskDuration;
            Instantiate(dropdowm, tasks[currentTaskIndex].DropDownPosition, transform.rotation);
            targetObject = tasks[currentTaskIndex].DropDownPosition;
            UIManager.activeTaskRecives(/*taskcounter, tasks[currentTaskIndex].rewardedCoins, tasks[currentTaskIndex].taskDuration*/);
            //timeManager.currentTime += 5;
            AudioManager.PlayPickUP();
            CurrentTaskIsDone = false;
            pickedup = false;
            //taskcounter++;
        }
    }
    // Update is called once per frame

    public void timeIsUp() {

        //TaskFaild = true;
        Debug.Log("hhhhhhhhhhhh");
        CreatNewTask();
        timeText.alpha = 0.0f;  
        AudioManager.playdTaskFaild();
        UIManager.TaskFaild();

        //TaskFaild=false;    
    }
    public void CreatNewTask()
    {
       
        if (currentTaskIndex >= tasks.Count)
        {
            //MakeItHarder();
            currentTaskIndex = 0;
            
        }
        DeployPickUpprefab();
        //SetTaskTime();





    }

    public void DeployPickUpprefab()
    {
        Instantiate(foodPrefab[currentTaskIndex], tasks[currentTaskIndex].PickUpPosition, transform.rotation);
        targetObject = tasks[currentTaskIndex].PickUpPosition;
        foodPrefab[currentTaskIndex].GetComponent<pickUp>().delveryPosition = tasks[currentTaskIndex].DropDownPosition;
    }
    public void SetTaskTime()
    {
        timeManager.currentTime = tasks[currentTaskIndex].taskDuration;
    }
}
public static class ListExtensions
{
    private static readonly System.Random rng = new System.Random();

    // Fisher-Yates shuffle algorithm
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}