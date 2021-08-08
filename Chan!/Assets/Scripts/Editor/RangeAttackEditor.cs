using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using Game;

namespace GameEditor
{
    [CustomEditor(typeof(RangeAttack))]
    [CanEditMultipleObjects]
    public class RangeAttackEditor : Editor
    {
        #region Fields
        private SerializedProperty _rangeType;
        private SerializedProperty _owner;
        private SerializedProperty _spawnPoint;
        private SerializedProperty _layers;
        private SerializedProperty _damage;
        private SerializedProperty _size;
        private SerializedProperty _poolKey;
        private SerializedProperty _projectile;
        private SerializedProperty _projectileDirection;

        private AnimBool _animFoldout;
        #endregion

        private void OnEnable()
        {
            #region Initialize all property fields
            _rangeType = serializedObject.FindProperty("_rangeType");
            _owner = serializedObject.FindProperty("Owner");
            _spawnPoint = serializedObject.FindProperty("AttackSpawnPoint");
            _layers = serializedObject.FindProperty("AttackLayers");
            _damage = serializedObject.FindProperty("AttackDamage");
            _size = serializedObject.FindProperty("_damageAreaSize");
            _poolKey = serializedObject.FindProperty("_poolKey");
            _projectile = serializedObject.FindProperty("_projectile");
            _projectileDirection = serializedObject.FindProperty("_projectileDirectionTransformReference");
            #endregion

            _animFoldout = new AnimBool(true);
            _animFoldout.valueChanged.AddListener(Repaint);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_rangeType);

            if(_rangeType.enumValueIndex == 2)
            {
                EditorGUILayout.PropertyField(_projectile);
            }


            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(_owner);

            EditorGUILayout.Space();

            _animFoldout.target = EditorGUILayout.Foldout(_animFoldout.target, "Damage Properties");

            if (EditorGUILayout.BeginFadeGroup(_animFoldout.faded))
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(_spawnPoint);
                if(_rangeType.enumValueIndex != 2)
                    EditorGUILayout.PropertyField(_size);
                EditorGUILayout.PropertyField(_layers);
                EditorGUILayout.PropertyField(_damage);
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndFadeGroup();

            EditorGUILayout.Space();

            if (_rangeType.enumValueIndex == 2)
            {
                EditorGUILayout.PropertyField(_projectileDirection);

                EditorGUILayout.Space();
                EditorGUILayout.Space();

                EditorGUILayout.PropertyField(_poolKey);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}