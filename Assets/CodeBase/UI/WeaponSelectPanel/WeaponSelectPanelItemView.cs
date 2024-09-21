using CodeBase.Extensions;
using CodeBase.Infrastructure.Services.Audio;
using CodeBase.StaticData.WeaponSelectPanel;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase.UI.WeaponSelectPanel
{
    public class WeaponSelectPanelItemView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _content;
        [SerializeField] private Outline outline;
        [SerializeField] private AudioClip _onSelect;

        private IAudioService _audioService;

        [HideInInspector] public WeaponSelectPanelItem Item;

        public event Action<WeaponSelectPanelItemView> OnClick;

        public void Construct(IAudioService audioService)
        {
            _audioService = audioService;
        }

        public void Initialize(WeaponSelectPanelItem item)
        {
            Item = item;
            _content.sprite = Item.Sprite;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(this);
        }
        public void Select()
        {
            _audioService.Play(_onSelect);

            _content.color = _content.color.WithAlpha(0.25f);
            outline.effectColor = outline.effectColor.WithAlpha(0.5f);
        }
        public void UnSelect()
        {
            _content.color = _content.color.WithAlpha(1);
            outline.effectColor = outline.effectColor.WithAlpha(1);
        }
    }
}