using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    string googlePlayID = "4035625";
    bool testMode = false;
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(googlePlayID, testMode);
    }
    public void DisplayInterstitialAD()
    {
        if (Advertisement.IsReady() && Random.value > 0.5)
        {
            Advertisement.Show();
            supportMe = false;
        }
    }
    bool supportMe = false;
    public void SupportMe()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
            supportMe = true;
        }
    }

    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            Debug.Log("Video finish");
            if (supportMe)
            {
                Advertisement.Show();
            }
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("The ad did not finish due to a skip");
            supportMe = false;
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.Log("The ad did not finish due to an error.");
            supportMe = false;
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("error AD");
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
    }
}
