using UnityEngine;

namespace CodeBase.UI.WeaponSelectPanel
{
    public class ItemPlacement : MonoBehaviour
    {
        public GameObject CurrentModel;

        public void InstantiateModel(GameObject model)
        {
            if (CurrentModel != null)
                Destroy(CurrentModel.gameObject);

            CurrentModel = Instantiate(model, transform);
            CurrentModel.transform.Rotate(0, 90, 0);
        }
    }
}