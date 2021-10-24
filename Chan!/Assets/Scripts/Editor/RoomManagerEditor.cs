using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Game.Rooms;

namespace GameEditor
{
    [CustomEditor(typeof(RoomController))]
    public class RoomManagerEditor : Editor
    {
        private SerializedProperty _roomsInScene, _fadeTime;

        private void OnEnable()
        {
            _roomsInScene = serializedObject.FindProperty("_rooms");
            _fadeTime = serializedObject.FindProperty("_fadeTime");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_roomsInScene);

            EditorGUILayout.PropertyField(_fadeTime);
            
            if (GUILayout.Button("Find Rooms"))
            {
                var t = (target as RoomController);
                t.FindAllRooms();
            }


            serializedObject.ApplyModifiedProperties();
        }
    }
}