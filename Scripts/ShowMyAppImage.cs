using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShowMyApp_API
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(ShowMyApp))]
    public class ShowMyAppImage : MonoBehaviour
    {
        private ShowMyApp ShowMyAppComponent;
        private Image QRCodeImage;

        public  void InstallUI()
        {
            ShowMyAppComponent = GetComponent<ShowMyApp>();
            QRCodeImage = GetComponent<Image>();
            foreach (Image tImage in GetComponentsInChildren<Image>())
            {
                tImage.color = ShowMyAppComponent.DesignColor;
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
