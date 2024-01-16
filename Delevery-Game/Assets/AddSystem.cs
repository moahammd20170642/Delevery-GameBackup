using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using TMPro;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class AddSystem : MonoBehaviour
{
    public GameObject loadScreen;
    public CoinsManager Coinsmanager;
    public GameObject rewardAddImage;
    public DeleveryManager deleveryManager;
    public bool addshowed = false;  
    //public TextMeshProUGUI totalCoinsTxt;

    public string appId = "ca-app-pub-4935788923123536~8596337980";// "ca-app-pub-3940256099942544~3347511713";
    

#if UNITY_ANDROID
    public string bannerId = "ca-app-pub-4935788923123536/2374528655";
    public  string interId = "ca-app-pub-4935788923123536/1277069403";
    public  string rewardedId = "ca-app-pub-4935788923123536/4809120301";
    //string nativeId = "ca-app-pub-3940256099942544/2247696110";

    //#elif UNITY_IPHONE
    //    string bannerId = "ca-app-pub-3940256099942544/2934735716";
    //    string interId = "ca-app-pub-3940256099942544/4411468910";
    //    string rewardedId = "ca-app-pub-3940256099942544/1712485313";
    //    string nativeId = "ca-app-pub-3940256099942544/3986624511";

#endif
   //here

    BannerView bannerView;
    InterstitialAd interstitialAd;
    RewardedAd rewardedAd;
    //private void Awake()
    //{
       



    //    if (SceneManager.GetActiveScene().buildIndex == 0)
    //    {
    //        LoadInterstitialAd();
    //        loadScreen.SetActive(false);
    //    }

    //    if (SceneManager.GetActiveScene().buildIndex == 1)
    //    {
    //        //ShowInterstitialAd();
    //        //loadScreen.SetActive(true);
    //    }

    //    //LoadRewardedAd();

      



    //}

    
    private void Start()
    {if (SceneManager.GetActiveScene().buildIndex == 0)
        {

            rewardAddImage.SetActive(false);
            loadScreen.SetActive(false);
        }
    
        //ShowCoins();
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        MobileAds.Initialize(initStatus => {

            print("Ads Initialised !!");
            LoadBannerAd();

            LoadInterstitialAd();
       

            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                LoadRewardedAd();
            }

        });

      


        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
           
            loadScreen.SetActive(false);
        }



        //if (Adds.addShowed == false && SceneManager.GetActiveScene().buildIndex == 0)
        //{

        //    ShowInterstitialAd();
        //}



    }

    #region Banner

    public void LoadBannerAd()
    {
        //create a banner
        CreateBannerView();

        //listen to banner events
        ListenToBannerEvents();

        //load the banner
        if (bannerView == null)
        {
            CreateBannerView();
        }

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        print("Loading banner Ad !!");
        bannerView.LoadAd(adRequest);//show the banner on the screen
    }
    void CreateBannerView()
    {

        if (bannerView != null)
        {
            DestroyBannerAd();
        }
        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Top);
    }

   
    void ListenToBannerEvents()
    {
        bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
        };
        // Raised when the ad is estimated to have earned money.
        bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Banner view paid {0} {1}." +
                adValue.Value +
                adValue.CurrencyCode);
        };
        // Raised when an impression is recorded for an ad.
        bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };
        // Raised when an ad opened full screen content.
        bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
        };
    }
    public void DestroyBannerAd()
    {

        if (bannerView != null)
        {
            print("Destroying banner Ad");
            bannerView.Destroy();
            bannerView = null;
        }
    }
    #endregion

    #region Interstitial

    public void LoadInterstitialAd()
    {
        //loadScreen.SetActive(true);
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        InterstitialAd.Load(interId, adRequest, (InterstitialAd ad, LoadAdError error) =>
        {
             //loadScreen.SetActive(true);
            if (error != null || ad == null)
            {
                //loadScreen.SetActive(false); 
                print("Interstitial ad failed to load" + error);
                //loadScreen.SetActive(false);
                //LoadInterstitialAd();
                return;
            }

            print("Interstitial ad loaded !!" + ad.GetResponseInfo());

            interstitialAd = ad;
            InterstitialEvent(interstitialAd);
          
        });

    }
    public void ShowInterstitialAd()
    { 
   
        loadScreen.SetActive(false);
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        /*     Adds.addShowed =true*/ ;

        }
        else
        {
            print("Intersititial ad not ready!!");

        }
    }
    public void InterstitialEvent(InterstitialAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Interstitial ad paid {0} {1}." +
                adValue.Value +
                adValue.CurrencyCode);
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
            LoadInterstitialAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
            LoadInterstitialAd();
        };
    }

    #endregion

    #region Rewarded

    public void LoadRewardedAd()
    {
        //loadScreen.SetActive(true);

        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        RewardedAd.Load(rewardedId, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                print("Rewarded failed to load" + error);
                if (rewardAddImage.activeInHierarchy == true)
                {
                    rewardAddImage.SetActive(false);
                }
                //loadScreen.SetActive(false);
                return;
            }
          
            print("Rewarded ad loaded !!");
            if (rewardAddImage.activeInHierarchy == false)
            {
                rewardAddImage.SetActive(true);
            }

            rewardedAd = ad;
            RewardedAdEvents(rewardedAd);
            //ShowRewardedAd(50);
        });
    }
    public void ShowRewardedAd(int coins)
    {

        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                
                print("Give reward to player !!");

               
                //if (SceneManager.GetActiveScene().buildIndex == 1)
                //{
                //    GrantCoins(coins);

                //    deleveryManager.coins = coins*2;
                //}


                if (SceneManager.GetActiveScene().buildIndex == 0)
                {
                    GrantCoins(coins);
                    Coinsmanager.changeCurrentCoins(PlayerPrefs.GetInt(prefs.coins));
                    
                }

            });
        }
        else
        {
            print("Rewarded ad not ready");
        }
    }
    public void RewardedAdEvents(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Rewarded ad paid {0} {1}." +
                adValue.Value +
                adValue.CurrencyCode);
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
            LoadRewardedAd();
            loadScreen.SetActive(false);
       

        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
            LoadRewardedAd();
            loadScreen.SetActive(false);
        
            };
    }

    #endregion


    //#region Native

    //public Image img;

    //public void RequestNativeAd()
    //{

    //    AdLoader adLoader = new AdLoader.Builder(nativeId).ForNativeAd().Build();
    //native
    //    adLoader.OnNativeAdLoaded += this.HandleNativeAdLoaded;
    //    adLoader.OnAdFailedToLoad += this.HandleNativeAdFailedToLoad;

    //    adLoader.LoadAd(new AdRequest.Builder().Build());
    //}

    //private void HandleNativeAdLoaded(object sender, NativeAdEventArgs e)
    //{
    //    print("Native ad loaded");
    //    this.nativeAd = e.nativeAd;

    //    Texture2D iconTexture = this.nativeAd.GetIconTexture();
    //    Sprite sprite = Sprite.Create(iconTexture, new Rect(0, 0, iconTexture.width, iconTexture.height), Vector2.one * .5f);

    //    img.sprite = sprite;

    //}

    //private void HandleNativeAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    //{
    //    print("Native ad failed to load" + e.ToString());

    //}
    //#endregion


    #region extra 

    void GrantCoins(int coins)
    {
        int crrCoins = PlayerPrefs.GetInt(prefs.coins);
        crrCoins += coins;
        PlayerPrefs.SetInt(prefs.coins,crrCoins);
    

        //ShowCoins();
    }
    //void ShowCoins()
    //{
    //    totalCoinsTxt.text = PlayerPrefs.GetInt("totalCoins").ToString();
    //}

    #endregion



}
