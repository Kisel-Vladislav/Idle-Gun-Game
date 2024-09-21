using CodeBase.Service;
using CodeBase.Weapons.Modifiers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.ModifierUI
{
    public class ModifiersPanel : MonoBehaviour
    {
        [SerializeField] private Transform contentParent;

        private readonly List<ModifiersView> _modifiers = new List<ModifiersView>();

        public event Action<Modifier> OnClick;

        private void OnDestroy()
        {
            ClearModifiers();
        }

        public void Add(ModifiersView modifiersView)
        {
            modifiersView.OnClick += HandleModifierClick;
            modifiersView.transform.SetParent(contentParent, false);
            _modifiers.Add(modifiersView);

        }
        public void Show() =>
            gameObject.SetActive(true);
        public void Hide() =>
            gameObject.SetActive(false);

        private void HandleModifierClick(Modifier modifier)
        {
            Hide();
            ClearModifiers();
            OnClick?.Invoke(modifier);
        }
        private void ClearModifiers()
        {
            foreach (var item in _modifiers)
            {
                item.OnClick -= HandleModifierClick;
                Destroy(item.gameObject);
            }
            _modifiers.Clear();
        }
    }
}