using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RedPoint.Scrips.Imp
{
    public class RedPointDisplayImp : MonoBehaviour
    {
#pragma warning disable
        /// <summary>
        /// 與 Editor 進行 connect 的參數，雖然沒有使用到，但一定要保留
        /// </summary>
        [SerializeField] private ERedPointDisplayType displayIndex;

        [SerializeField] private TextMeshProUGUI displayTextMesPro;

        [SerializeField] private Text displayText;

        [SerializeField] private Image displayImage;

#pragma warning restore

        /// <summary>
        /// 設置是否可以看到紅點提示圖片
        /// </summary>
        /// <param name="value"></param>
        public void SetVisibleImage(bool value)
        {
            if (displayImage == null) return;
            displayImage.gameObject.SetActive(value);
        }

        /// <summary>
        /// 設置紅點點數
        /// </summary>
        /// <param name="value"></param>
        public void SetNumCount(string value)
        {
            if (displayText != null)
                displayText.text = value;
            if (displayTextMesPro != null)
                displayTextMesPro.text = value;
        }

        // private void DoVisible(bool value)
        // {
        //     if (displayText != null)
        //     {
        //         if(displayText.gameObject.activeSelf)
        //             displayText.gameObject.SetActive(value);
        //     }
        //     if (displayImage != null)
        //     {
        //         if(displayImage.gameObject.activeSelf)
        //             displayImage.gameObject.SetActive(value);
        //     }
        //     if (displayTextMesPro != null)
        //     {
        //         if(displayTextMesPro.gameObject.activeSelf)
        //             displayTextMesPro.gameObject.SetActive(value);
        //     }
        // }
    }
}