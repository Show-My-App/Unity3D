using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowMyAppController : MonoBehaviour
{
    public Image ImageQRCode;
    public ShowMyApp ShowMyAppInstance;

    void Start()
    {
        if (ShowMyAppInstance != null)
        {
            ShowMyAppInstance.InsertQRCode(ImageQRCode);
        }
    }

    public void Share()
    {
    if (ShowMyAppInstance != null)
        {
            ShowMyAppInstance.Share();
        }
    }

    public void Powered()
    {
        if (ShowMyAppInstance != null)
        {
            ShowMyAppInstance.Powered();
        }
    }
}
