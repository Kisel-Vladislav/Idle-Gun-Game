using CodeBase.Player;
using CodeBase.UI.Bar;
using System;
using UnityEngine;

namespace CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        public ProgressBar ExpBar;

        private LevelProgression _levelProgression;

        public void Construct(LevelProgression levelProgression)
        {
            _levelProgression = levelProgression;
            _levelProgression.OnExperienceChanged += UpdateExpBar;
        }

        public void OnDestroy()
        {
            _levelProgression.OnExperienceChanged -= UpdateExpBar;
        }

        private void UpdateExpBar()
        {
            ExpBar.SetValue(_levelProgression.Experience, _levelProgression.ExperienceToNextLevel);
        }
    }
}