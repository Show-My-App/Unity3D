using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowMyAppController : MonoBehaviour
{
    public Text TextURL;
    public Text TextTinyURL;
    public Image ImageQRCode;
    public Image ImageTinyQRCode;

    public ShowMyApp ShowMyAppInstance;

    // Start is called before the first frame update
    void Start()
    {
        BasicToolBox.BTBAlert.Alert("TEST", "alert");
        ShowMyAppInstance.InsertURL(TextURL);
        ShowMyAppInstance.InsertTinyURL(TextTinyURL);
        ShowMyAppInstance.InsertQRCode(ImageQRCode);
        ShowMyAppInstance.InsertTinyQRCode(ImageTinyQRCode);
    }

    public void ShareURL()
    {
        ShowMyAppInstance.Share();
    }

    public void ShareTinyURL()
    {
        ShowMyAppInstance.ShareTiny();
    }
}
