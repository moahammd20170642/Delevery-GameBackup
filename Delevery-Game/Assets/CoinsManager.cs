using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SIS;
public class CoinsManager : MonoBehaviour
{
    public int totalcoins;
    public TextMeshProUGUI coinsText;


    private void Start()
    {
        // totalcoins = PlayerPrefs.GetInt(prefs.coins, 0);
        totalcoins = DBManager.GetCurrency("coins");
        coinsText.text = "" + totalcoins;
    }

    public void changeCurrentCoins(int coins)
    {
        totalcoins = coins;
        coinsText.text = "" + totalcoins;


    }
}
