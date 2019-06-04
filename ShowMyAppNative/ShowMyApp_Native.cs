// ====================================================================================================================
//
//  ideMobi 2019©
//
//  Date        2019-5-28 14:00:00
//  Author      Kortex (Jean-François CONTART) 
//  Email       jfcontart@idemobi.com
//  Project     NetWorkedData for Unity3D
//
//  All rights reserved by ideMobi
//
// ====================================================================================================================

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
