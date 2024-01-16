using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
   
    //public GameObject GameOverUI;
    public RectTransform TaskPanel , taskrecivedpanel;
   public DeleveryManager DeleveryManager;
    public TextMeshProUGUI UiTaskCoins;
    public TextMeshProUGUI UiTaskTime;
    public TextMeshProUGUI GrantedcoinsUI;
    public GameObject pauseMenuUI;

    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game by setting time scale to 0
        pauseMenuUI.SetActive(true);
       AudioListener.volume = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game by setting time scale back to 1
        pauseMenuUI.SetActive(false);
        AudioListener.volume = 1f;
    }
    
    public void goHome()
    {
        Time.timeScale = 1f; // Resume the game by setting time scale back to 1
        AudioListener.volume = 1f;

        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        Time.timeScale = 1f; // Resume the game by setting time scale back to 1
        AudioListener.volume = 1f;

        SceneManager.LoadScene(1);
    }
    private void Start()
    {
        TaskPanel.gameObject.SetActive(false);
        taskrecivedpanel.gameObject.SetActive(false);
    }
   
    //public void ShowGameOverUI()
    //{
    //    GameOverUI.SetActive(true);/////////////////////////////
      
    //}
    public void ActivateTaskUI( int coins, int time)
    {

        StartCoroutine(TaskUI(coins, time));
    }

    public void activeTaskRecives() {
        StartCoroutine(Taskrecieved());
    }
    IEnumerator TaskUI( int coins, int time)
    {
        TaskPanel.gameObject.SetActive(true);
       
        UiTaskCoins.text = ("+ " + coins);
        UiTaskTime.text = ( "+ " + time+" S");


        //TaskPanel.anchoredPosition = new Vector2(0, 200);
        //TaskPanel.DOMoveY(-258, 1f);
        yield return new WaitForSeconds(4);
        //TaskPanel.DOMoveY(200, 1f);
       
        TaskPanel.gameObject.SetActive(false);

    }

    IEnumerator Taskrecieved()
    {
       taskrecivedpanel.gameObject.SetActive(true);
      


        taskrecivedpanel.anchoredPosition = new Vector2(-150, 0);
        taskrecivedpanel.DOMoveX(150, 1f);
        yield return new WaitForSeconds(2);
        taskrecivedpanel.DOMoveX(-150, 1f);
        yield return new WaitForSeconds(1);

        taskrecivedpanel.gameObject.SetActive(false);

    }

}
