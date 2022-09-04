using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textFuel : MonoBehaviour
{
    private Text txt;
    void Start()
    {
        txt = GetComponent<Text>();
    }

    void Update()
    {
        txt.text = "Extra Fuel: " + RewardedAdsButton.rewardedProp.ToString();
    }
}
