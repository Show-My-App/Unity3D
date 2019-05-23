using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace ShowMyApp_API
{
    public delegate void ShowMyAppDelegateQRCode(Texture2D sQRCode);
    public delegate void ShowMyAppDelegateURL(string sURL);

    public enum ShowMyAppDesign : int
    {
        a = 0,
        b = 1,
        c = 2,
        d = 3,
    }

    public partial class ShowMyApp : MonoBehaviour
    {
        const string website = "https://www.show-my-app.com/";
        [Header("General Design")]
        [Tooltip("The name of your app collection")]
        public string AppName; // &n=xxxxx
        [Tooltip("The design of webpage redirection")]
        public ShowMyAppDesign Design; // &d=xxxxx
        [Tooltip("The color of hard line")]
        public Color DesignColor; // &c=xxxxx
        [Tooltip("The color of background")]
        public Color DesignColorBackground; // &k=xxxxx
        [Tooltip("Use short url and tiny QRCode")]
        public bool Tiny;  // &t=xxxxx
        [Tooltip("Use only one icon on webpage")]
        public bool OneIconOnly;  // &i=xxxxx

        [Header("Apple©")]
        [Tooltip("The App's Identifiant Apple in App Store Connect (example : 123456789)")]
        public string iOS_iPhone_BundleID; // &a=xxxxx
        [Tooltip("The App's Identifiant Apple in App Store Connect (example : 123456789)")]
        public string iOS_iPad_BundleID; // &b=xxxxx
        [Tooltip("The App's Identifiant Apple in App Store Connect (example : 123456789)")]
        public string macOS_BundleID; // &m=xxxxx
        [Tooltip("The App's Identifiant Apple in App Store Connect (example : 123456789)")]
        public string tvOS_BundleID; // &v=xxxxx

        [Header("Google©")]
        [Tooltip("The App's bundle id in Google Play (example : com.company.app)")]
        public string android_BundleID;  // &g=xxxxx
        [Tooltip("The App's bundle id in Google Play (example : com.company.app)")]
        public string android_Tablet_BundleID;  // &h=xxxxx

        //[Header("Microsoft©")]
        //public string windows_BundleID;  // &w=xxxxx
        //public string windows_Phone_BundleID;  // &x=xxxxx

        //[Header("Steam©")]
        //public string steam_BundleID;  // &s=xxxxx

        #region private
        private bool TinyURLRequest = false;
        private string TinyURL;
        private bool QRCodeRequest = false;
        private Texture2D QRCode;
        private bool TinyQRCodeRequest = false;
        private Texture2D TinyQRCode;
        #endregion

        #region URL Create
        private string GetParam()
        {
            List<string> tRequestList = new List<string>();
            if (string.IsNullOrEmpty(AppName) == false)
            {
                tRequestList.Add("n=" + AppName);
            }
            tRequestList.Add("d=" + ((int)Design).ToString());
            tRequestList.Add("c=" + ColorUtility.ToHtmlStringRGBA(DesignColor));
            tRequestList.Add("k=" + ColorUtility.ToHtmlStringRGBA(DesignColorBackground));
            if (OneIconOnly == true)
            {
                tRequestList.Add("i=1");
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
            if (string.IsNullOrEmpty(tvOS_BundleID) == false)
            {
                tRequestList.Add("v=" + tvOS_BundleID);
            }
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
        #endregion

        #region Get URL
        public void GetURL(ShowMyAppDelegateURL sDelegate)
        {
            if (Tiny == true)
            {
                GetTinyURL(sDelegate);
            }
            else
            {
                GetFullURL(sDelegate); ;
            }
        }

        public void GetFullURL(ShowMyAppDelegateURL sDelegate)
        {
            string rReturn = website + "r.php?" + GetParam();
            sDelegate(rReturn);
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
            string tURI = website + "url.php?t=1&" + GetParam();
            Debug.Log("GetTinyURLAsync() => tURI = " + tURI);
            UnityWebRequest www = UnityWebRequest.Get(tURI);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                TinyURL = www.downloadHandler.text;
                Debug.Log("GetTinyURLAsync() => tURI result = " + TinyURL);
                sDelegate?.Invoke(TinyURL);
            }
            TinyURLRequest = false;
        }

        #endregion

        #region Get QRCode
        public void GetQRCode(ShowMyAppDelegateQRCode sDelegate)
        {
            if (Tiny == true)
            {
                GetTinyQRCode(sDelegate);
            }
            else
            {
                GetFullQRCode(sDelegate);
            }
        }

        public void GetFullQRCode(ShowMyAppDelegateQRCode sDelegate)
        {
            if (QRCodeRequest == false)
            {
                QRCodeRequest = true;
                StartCoroutine(GetFullQRCodeAsync(sDelegate));
            }
        }

        private IEnumerator GetFullQRCodeAsync(ShowMyAppDelegateQRCode sDelegate)
        {
            string tURI = website + "qrcode.php?" + GetParam();
            Debug.Log("GetFullQRCodeAsync() => tURI = " + tURI);
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
            string tURI = website + "qrcode.php?t=1&" + GetParam();
            Debug.Log("GetTinyQRCodeAsync() => tURI = " + tURI);
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

        #endregion

        #region Insert URL
        public void InsertURL(Text sText)
        {
            if (Tiny == true)
            {
                InsertTinyURL(sText);
            }
            else
            {
                InsertFullURL(sText);
            }
        }

        public void InsertFullURL(Text sText)
        {
            GetFullURL(delegate (string sURL) { sText.text = sURL; });
        }

        public void InsertTinyURL(Text sText)
        {
            GetTinyURL(delegate (string sURL) { sText.text = sURL; });
        }
        #endregion

        #region Insert QRCode
        public void InsertQRCode(Image sImage)
        {

            if (Tiny == true)
            {
                InsertTinyQRCode(sImage);
            }
            else
            {
                InsertFullQRCode(sImage);
            }
        }

        public void InsertFullQRCode(Image sImage)
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
        #endregion

        #region Powered By
        public void Powered()
        {
            Application.OpenURL(website);
        }
        #endregion

        #region Share test
        public void ShareInWebBrowser()
        {
            GetURL(delegate (string sURL) { Application.OpenURL(sURL); });
        }
        #endregion
    }
}
