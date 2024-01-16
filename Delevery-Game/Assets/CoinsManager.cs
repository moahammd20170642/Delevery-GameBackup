using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinsManager : MonoBehaviour
{
    public int totalcoins;
    public TextMeshProUGUI coinsText;


    private void Start()
    {
        totalcoins = PlayerPrefs.GetInt(prefs.coins, 0);

        coinsText.text = "" + totalcoins;
    }

    public void changeCurrentCoins(int coins)
    {
        totalcoins = coins;
        coinsText.text = "" + totalcoins;


    }
}
