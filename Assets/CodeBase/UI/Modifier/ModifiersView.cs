using CodeBase.Extensions;
using CodeBase.Weapons.Modifiers;
using PrimeTween;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase.UI.ModifierUI
{
    public class ModifiersView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private Modifier _modifier;

        private Color _select;
        private Color _normal;

        public TextMeshProUGUI _Description;
        public TextMeshProUGUI _rarity;

        public Image background;
        public float Duration = 0.5f;

        public event Action<Modifier> OnClick;

        public void Construct(Modifier modifier, Color color)
        {
            _modifier = modifier;
            _Description.text = modifier.Description;
            _rarity.text = modifier.RarityType.ToString();

            background.color = color.WithAlpha(0.5f);
            _select = color;
            _normal = background.color;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(_modifier);
        }
        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            Tween.Color(background, background.color, _normal, Duration)
                 .Group(Tween.Scale(transform, transform.localScale, Vector3.one, Duration));
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            Tween.Color(background, background.color, _select, Duration)
                 .Group(Tween.Scale(transform, transform.localScale, Vector3.one * 1.1f, Duration));
        }
    }
}