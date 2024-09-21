using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Bar
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] protected Image _imageCurrent;
        [SerializeField] protected TextMeshProUGUI text;
        public virtual void SetValue(float current, float max)
        {
            Tween.UIFillAmount(_imageCurrent, current / max, 0.5f);
            text.text = $"{current}/{max}";
        }
    }
}