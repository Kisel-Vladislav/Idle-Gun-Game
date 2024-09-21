using CodeBase.Service;
using UnityEngine;

namespace CodeBase.UI.Bar
{
    public class SegmentedProgressBar : ProgressBar
    {
        [SerializeField] private int _segmentCount;

        public override void SetValue(float current, float max) =>
            _imageCurrent.fillAmount = current / max * _segmentCount * 1 / _segmentCount;
    }
}