using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

using BasicToolBox;
public partial class ShowMyApp : MonoBehaviour
{
    #region Share
    public void Share()
    {
        if (Tiny == true)
        {
            ShareTiny();
        }
        else
        {
            ShareFull();
        }
    }

    public void ShareTiny()
    {
        GetTinyURL(delegate (string sURL)
        {
            BTBShare.Share("TEST Tiny", sURL);
        }
        );
    }

    public void ShareFull()
    {
        GetFullURL(delegate (string sURL)
        {
            BTBShare.Share("TEST Tiny", sURL);
        }
        );
    }
    #endregion
}
