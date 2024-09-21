using System;

namespace CodeBase.Player
{
    public class LevelProgression
    {
        private int _experience;
        private int _experienceToNextLevel;
        private int _level;

        public int Experience { get => _experience; }
        public int ExperienceToNextLevel { get => _experienceToNextLevel; }

        public event Action OnLevelUp;
        public event Action OnExperienceChanged;

        public LevelProgression()
        {
            InitNew();
            OnExperienceChanged?.Invoke();
        }
        public void AddExperience(int x)
        {
            if (_experience < 0)
                throw new ArgumentException("Experience cannot be negative");

            _experience += x;

            if (HasLeveledUp())
                LevelUp();

            OnExperienceChanged?.Invoke();
        }
        public void Reset() =>
            InitNew();

        private void LevelUp()
        {
            _experience = 0;
            _level++;

            CalculateExperienceToNextLevel();

            OnLevelUp?.Invoke();
        }
        private void CalculateExperienceToNextLevel()
        {
            _experienceToNextLevel *= _level;
        }
        private bool HasLeveledUp() =>
            _experience >= _experienceToNextLevel;
        private void InitNew()
        {
            _experience = 0;
            _level = 0;
            _experienceToNextLevel = 100;
        }

    }
}