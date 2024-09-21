using CodeBase.StaticData.Enemy;
using UnityEditor;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(EnemyStaticData))]
    public class EnemyStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var enemyData = (EnemyStaticData)target;

            DisplayBasicSettingsSection(enemyData);
            EditorGUILayout.Space();
            DisplayMoveSettingsSection(enemyData);
            EditorGUILayout.Space();
            DisplayAttackSettingsSection(enemyData);
            serializedObject.ApplyModifiedProperties();
        }

        private void DisplayMoveSettingsSection(EnemyStaticData enemyData)
        {
            EditorGUILayout.LabelField("Move Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(enemyData.MoveSpeed)));
        }

        private void DisplayAttackSettingsSection(EnemyStaticData enemyData)
        {
            EditorGUILayout.LabelField("Attack Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(enemyData.AttackType)));

            switch (enemyData.AttackType)
            {
                case EnemyAttackType.Overlap:
                    DisplayAttackData(serializedObject.FindProperty(nameof(enemyData.OverlapAttackData)));
                    break;
                case EnemyAttackType.Explore:
                    DisplayAttackData(serializedObject.FindProperty(nameof(enemyData.ExploreAttackData)));
                    break;
            }
        }

        private void DisplayBasicSettingsSection(EnemyStaticData enemyData)
        {
            EditorGUILayout.LabelField("Basic Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(enemyData.Id)));
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(enemyData.Prefab)));
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(enemyData.MaxHealth)));
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(enemyData.ExperienceReward)));
        }

        private void DisplayAttackData(SerializedProperty attackDataProperty)
        {
            EditorGUILayout.LabelField(attackDataProperty.displayName, EditorStyles.boldLabel);
            foreach (SerializedProperty item in attackDataProperty)
            {
                EditorGUILayout.PropertyField(item);
            }
        }
    }
}