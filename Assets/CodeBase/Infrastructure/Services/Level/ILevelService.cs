using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure.Services.Level
{
    public interface ILevelService
    {
        public WordObjectCollector WordObjectCollector { get; set; }
        public LevelProgressWatcher ProgressWatcher { get; set; }

    }
}