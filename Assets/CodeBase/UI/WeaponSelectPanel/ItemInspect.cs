using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.UI.WeaponSelectPanel
{
    public class ItemInspect : MonoBehaviour, IDragHandler
    {
        public Transform InspectItem;
        public void OnDrag(PointerEventData eventData)
        {
            InspectItem.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x);
        }
    }
}