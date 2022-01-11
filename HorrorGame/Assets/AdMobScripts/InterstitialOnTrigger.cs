﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;

public class InterstitialOnTrigger : MonoBehaviour
{
     private InterstitialAd interstitial;

   private void RequestInterstitial()
   {
      #if UNITY_ANDROID
         string adUnitId = "ca-app-pub-8363350638806517/3267220886";
      #elif UNITY_IPHONE
         string adUnitId = "ca-app-pub-3940256099942544/4411468910";
      #else
         string adUnitId = "unexpected_platform";
      #endif

      // Initialize an InterstitialAd.
      this.interstitial = new InterstitialAd(adUnitId);
      // Called when the ad is closed.
      this.interstitial.OnAdClosed += HandleOnAdClosed;
      // Create an empty ad request.
      AdRequest request = new AdRequest.Builder().Build();
      // Load the interstitial with the request.
      this.interstitial.LoadAd(request);
      
      Debug.Log("Ad Requested");
   }

   private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "RequestAd")
       {
           RequestInterstitial();
       }
       if(other.tag == "Ad" && this.interstitial.IsLoaded())
       {
           this.interstitial.Show();
           Debug.Log("Ad activated");
       }
   }
   public void HandleOnAdClosed(object sender, EventArgs args)
   {
      interstitial.Destroy();
      Debug.Log("interstitial destroyed");
   }
}
