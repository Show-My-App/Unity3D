using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShowMyApp_API
{
    public class ShowMyAppImage : MonoBehaviour
    {
        
    public Image QRCodeImage;
    public Image QRCodeOverlayImage;
    public ShowMyApp ShowMyAppComponent;
        public  void InstallUI()
        {
            if (QRCodeImage != null)
            {
                QRCodeImage.color = ShowMyAppComponent.DesignColor;
            }
            if (QRCodeOverlayImage != null)
            {
                QRCodeOverlayImage.color = ShowMyAppComponent.DesignColor;
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            InstallUI();
            if (QRCodeImage != null)
            {
                ShowMyAppComponent.InsertQRCode(QRCodeImage);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDrawGizmos()
        {
            InstallUI();
        }
    }
}
