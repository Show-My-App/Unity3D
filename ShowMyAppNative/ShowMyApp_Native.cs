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
        public void Share(ShowMyAppShareOnCompleteBlock sCompleteBlock = null)
        {
            if (Tiny == true)
            {
                ShareTiny(sCompleteBlock);
            }
            else
            {
                ShareFull(sCompleteBlock);
            }
        }

        public void ShareTiny(ShowMyAppShareOnCompleteBlock sCompleteBlock)
        {
            GetTinyURL(delegate (string sURL)
            {
                ShowMyAppShare.Share(Message + "\n" + sURL, sCompleteBlock);
            }
            );
        }

        public void ShareFull(ShowMyAppShareOnCompleteBlock sCompleteBlock)
        {
            GetFullURL(delegate (string sURL)
            {
                ShowMyAppShare.Share(Message + "\n" + sURL, sCompleteBlock);
            }
            );
        }
        #endregion
    }
}
