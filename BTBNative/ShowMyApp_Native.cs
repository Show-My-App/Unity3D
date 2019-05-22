using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

using BasicToolBox;
public partial class ShowMyApp : MonoBehaviour
{
    public void Share()
    {
        BTBShare.Share("TEST", CreateURL());
    }

    public void ShareTiny()
    {
        GetTinyURL(delegate (string sURL)
        {
            BTBShare.Share("TEST Tiny", sURL);
        }
        );
    }
}
