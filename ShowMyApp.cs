using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public delegate void ShowMyAppDelegateQRCode(Texture2D sQRCode);
public delegate void ShowMyAppDelegateURL(string sURL);

public partial class ShowMyApp : MonoBehaviour
{
    const string website = "https://www.show-my-app.com/";
    const string tiny = "tiny=1&";
    
    public string AppName; // &n=xxxxx

    public string Design; // &d=xxxxx

    public string iOS_iPhone_BundleID; // &a=xxxxx
    public string iOS_iPad_BundleID; // &b=xxxxx
    public string macOS_BundleID; // &m=xxxxx
                                  //public string tvOS_BundleID; // &q=xxxxx

    public string android_BundleID;  // &g=xxxxx
    public string android_Tablet_BundleID;  // &h=xxxxx

    //public string windows_BundleID;  // &w=xxxxx
    //public string windows_Phone_BundleID;  // &x=xxxxx

    //public string steam_BundleID;  // &s=xxxxx

    private bool TinyURLRequest = false;
    private string TinyURL;
    private bool QRCodeRequest = false;
    private Texture2D QRCode;
    private bool TinyQRCodeRequest = false;
    private Texture2D TinyQRCode;

    private string GetParam()
    {
        List<string> tRequestList = new List<string>();
        if (string.IsNullOrEmpty(AppName) == false)
        {
            tRequestList.Add("n=" + AppName);
        }
        if (string.IsNullOrEmpty(Design) == false)
        {
            tRequestList.Add("d=" + Design);
        }
        if (string.IsNullOrEmpty(iOS_iPhone_BundleID) == false)
        {
            tRequestList.Add("a=" + iOS_iPhone_BundleID);
        }
        if (string.IsNullOrEmpty(iOS_iPad_BundleID) == false)
        {
            if (iOS_iPad_BundleID != iOS_iPhone_BundleID)
            {
                tRequestList.Add("b=" + iOS_iPad_BundleID);
            }
        }
        if (string.IsNullOrEmpty(macOS_BundleID) == false)
        {
            tRequestList.Add("m=" + macOS_BundleID);
        }
        //if (string.IsNullOrEmpty(tvOS_BundleID) == false)
        //{
        //    tRequestList.Add("q=" + tvOS_BundleID);
        //}
        if (string.IsNullOrEmpty(android_BundleID) == false)
        {
            tRequestList.Add("g=" + android_BundleID);
        }
        if (string.IsNullOrEmpty(android_Tablet_BundleID) == false)
        {
            if (android_Tablet_BundleID != android_BundleID)
            {
                tRequestList.Add("h=" + android_Tablet_BundleID);
            }
        }
        //if (string.IsNullOrEmpty(windows_BundleID) == false)
        //{
        //    tRequestList.Add("w=" + windows_BundleID);
        //}
        //if (string.IsNullOrEmpty(windows_Phone_BundleID) == false)
        //{
        //    tRequestList.Add("x=" + windows_Phone_BundleID);
        //}
        //if (string.IsNullOrEmpty(steam_BundleID) == false)
        //{
        //    tRequestList.Add("s=" + steam_BundleID);
        //}
        return string.Join("&", tRequestList);
    }

    public string CreateURL()
    {
        string rReturn = website + "r.php?" + GetParam();
        return rReturn;
    }

    public void GetTinyURL(ShowMyAppDelegateURL sDelegate)
    {
        if (TinyURLRequest == false)
        {
            TinyURLRequest = true;
            StartCoroutine(GetTinyURLAsync(sDelegate));
        }
    }

    private IEnumerator GetTinyURLAsync(ShowMyAppDelegateURL sDelegate)
    {
        string tURI = website + "url.php?" + tiny + GetParam();
        //Debug.Log("GetTinyURLAsync() => tURI = " + tURI);
        UnityWebRequest www = UnityWebRequest.Get(tURI);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            TinyURL = www.downloadHandler.text;
            sDelegate?.Invoke(TinyURL);
        }
        TinyURLRequest = false;
    }

    public void GetQRCode(ShowMyAppDelegateQRCode sDelegate)
    {
        if (QRCodeRequest == false)
        {
            QRCodeRequest = true;
            StartCoroutine(GetQRCodeAsync(sDelegate));
        }
    }

    private IEnumerator GetQRCodeAsync(ShowMyAppDelegateQRCode sDelegate)
    {
        string tURI = website + "qrcode.php?" + GetParam();
        //Debug.Log("GetQRCodeAsync() => tURI = " + tURI);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(tURI);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            QRCode = ((DownloadHandlerTexture)www.downloadHandler).texture;
            sDelegate?.Invoke(QRCode);
        }
        QRCodeRequest = false;
    }

    public void GetTinyQRCode(ShowMyAppDelegateQRCode sDelegate)
    {
        if (TinyQRCodeRequest == false)
        {
            TinyQRCodeRequest = true;
            StartCoroutine(GetTinyQRCodeAsync(sDelegate));
        }
    }

    private IEnumerator GetTinyQRCodeAsync(ShowMyAppDelegateQRCode sDelegate)
    {
        string tURI = website + "qrcode.php?" + tiny + GetParam();
        //Debug.Log("GetTinyQRCodeAsync() => tURI = " + tURI);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(tURI);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            TinyQRCode = ((DownloadHandlerTexture)www.downloadHandler).texture;
            sDelegate?.Invoke(TinyQRCode);
        }
        TinyQRCodeRequest = false;
    }

    public void InsertURL(Text sText)
    {
        sText.text = CreateURL();
    }

    public void InsertTinyURL(Text sText)
    {
        GetTinyURL(delegate (string sURL) { sText.text = sURL; });
    }

    public void InsertQRCode(Image sImage)
    {
        GetQRCode(delegate (Texture2D sTexture2D)
        {
            Sprite rSprite = null;
            if (sTexture2D != null)
            {
                rSprite = Sprite.Create(sTexture2D, new Rect(0, 0, sTexture2D.width, sTexture2D.height), new Vector2(0.5f, 0.5f));
            }
            sImage.sprite = rSprite;
        });
    }

    public void InsertTinyQRCode(Image sImage)
    {
        GetTinyQRCode(delegate (Texture2D sTexture2D)
        {
            Sprite rSprite = null;
            if (sTexture2D != null)
            {
                rSprite = Sprite.Create(sTexture2D, new Rect(0, 0, sTexture2D.width, sTexture2D.height), new Vector2(0.5f, 0.5f));
            }
            sImage.sprite = rSprite;
        });
    }

}
