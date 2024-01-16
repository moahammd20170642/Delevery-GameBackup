using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public AddSystem ad;
    public Load load;
   public void loadGameScene(int x )
    {
        if (x == 1)//if we are going from home to game
        {
            PlayerPrefs.SetInt(prefs.SelectedCar, load.currentImageIndex);

        }
        SceneManager.LoadScene(x);
    }
    public void loadAndShow()
    {
        ad.ShowInterstitialAd();
        loadGameScene(1);

    }

   
}
