using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadShop : MonoBehaviour
{
    public GameObject shop , scene;
    public void loadShopScene()
    {

        shop.SetActive(true);
        scene.SetActive(false);

    }


    public void loadSceneff()
    {

        shop.SetActive(false);
        scene.SetActive(true);

    }

}
