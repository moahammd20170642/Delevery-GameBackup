using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Load : MonoBehaviour
{
    public AddSystem AddSystem;
    public List<GameObject> imageObjects;
    public   int currentImageIndex = 0;

    public  Button Go, buy;

    public int CurrentCoins;
   public CoinsManager CoinsManager;
    public TextMeshProUGUI pricetext;
    private void Start()
    {
        //imageObjects[0].GetComponent<Car>().IsOwned = true;//////////first car is always owned

        PlayerPrefs.SetInt("FrstCar", 1);


        CurrentCoins = PlayerPrefs.GetInt(prefs.coins, 0);
        currentImageIndex = PlayerPrefs.GetInt(prefs.SelectedCar,0);
        ShowCurrentImage();



    }

    public void LoadNextImage()
    {
        if (imageObjects.Count == 0)
            return;

        imageObjects[currentImageIndex].SetActive(false);

        currentImageIndex = (currentImageIndex + 1) % imageObjects.Count;

        ShowCurrentImage();
    }

    public void LoadPreviousImage()
    {
        if (imageObjects.Count == 0)
            return;

        imageObjects[currentImageIndex].SetActive(false);

        currentImageIndex = (currentImageIndex - 1 + imageObjects.Count) % imageObjects.Count;

        ShowCurrentImage();
    }

   
    private void ShowCurrentImage()
    {
        string carname = imageObjects[currentImageIndex].GetComponent<Car>().carName;

        imageObjects[currentImageIndex].SetActive(true);


        if (PlayerPrefs.GetInt(carname, 0) == 1)/////car is owned
        {

            buy.gameObject.SetActive(false);
            Go.gameObject.SetActive(true);


        }

        else
        {
            pricetext.text = "" +imageObjects[currentImageIndex].GetComponent<Car>().price;
            buy.gameObject.SetActive(true);
            Go.gameObject.SetActive(false);


        }



    }
    
    public void Buycar()
    {
        CurrentCoins=PlayerPrefs.GetInt(prefs.coins, 0);    

        if (CurrentCoins >= imageObjects[currentImageIndex].GetComponent<Car>().price)
        {
            CurrentCoins -= imageObjects[currentImageIndex].GetComponent<Car>().price;
            PlayerPrefs.SetInt(prefs.coins, CurrentCoins);
            CoinsManager.changeCurrentCoins(CurrentCoins);
            PlayerPrefs.SetInt(imageObjects[currentImageIndex].GetComponent<Car>().carName, 1);
            buy.gameObject.SetActive(false);
            Go.gameObject.SetActive(true);

        }

        else
        {
            return;
        }
    }
}

