using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Player;
using CodeBase.StaticData;
using CodeBase.UI.ModifierUI;
using CodeBase.Weapons.Modifiers;
using UnityEngine;
using Zenject;
public class ModifierSystemController : MonoBehaviour
{
    [SerializeField] private ModifiersPanel _modifiersPanel;

    private ModifiersViewFactory _factory;
    private ModifierFactory _modifierFactory;
    private LevelProgression _levelSystem;
    private ModifiersService _modifiersService;
    private PauseService _pauseService;

    [Inject]
    public void Construct(PauseService pauseService, ModifiersViewFactory factory, LevelProgression levelProgression, ModifiersService modifiersService, ModifierFactory modifierFactory)
    {
        _pauseService = pauseService;
        _factory = factory;
        _levelSystem = levelProgression;
        _modifiersService = modifiersService;
        _modifierFactory = modifierFactory;
    }

    public void Initialize()
    {
        _levelSystem.OnLevelUp += ShowPanel;
        _modifiersPanel.OnClick += AddModifier;
    }

    private void AddModifier(Modifier modifier)
    {
        _modifiersService.AddModifier(modifier);
        _pauseService.SetPaused(isPaused: false);
    }
    private void OnDestroy()
    {
        _levelSystem.OnLevelUp -= ShowPanel;
        _modifiersPanel.OnClick -= AddModifier;
    }
    private void ShowPanel()
    {
        GenerateModifiers();
        _modifiersPanel.Show();

        _pauseService.SetPaused(isPaused: true);
    }

    private void GenerateModifiers()
    {
        for (int i = 0; i < 3; i++)
        {
            var modifier = _modifierFactory.CreateRandom(RarityType.Legendary);
            var modifiersView = _factory.Create(modifier);
            _modifiersPanel.Add(modifiersView);
        }
    }
}
