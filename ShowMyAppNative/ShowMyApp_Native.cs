using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace ShowMyApp_API
{
    public partial class ShowMyApp : MonoBehaviour
    {
        #region Share
        public void Share(string sMessage, ShowMyAppShareOnCompleteBlock sCompleteBlock = null)
        {
            if (Tiny == true)
            {
                ShareTiny(sMessage, sCompleteBlock);
            }
            else
            {
                ShareFull(sMessage, sCompleteBlock);
            }
        }

        public void ShareTiny(string sMessage, ShowMyAppShareOnCompleteBlock sCompleteBlock)
        {
            GetTinyURL(delegate (string sURL)
            {
                ShowMyAppShare.Share(sMessage +"\n"+ sURL, sCompleteBlock);
            }
            );
        }

        public void ShareFull(string sMessage, ShowMyAppShareOnCompleteBlock sCompleteBlock)
        {
            GetFullURL(delegate (string sURL)
            {
                ShowMyAppShare.Share(sMessage +"\n"+ sURL, sCompleteBlock);
            }
            );
        }
        #endregion
    }
}
