using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Game.Camera
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _pauseCvm;

        public CinemachineVirtualCamera _currentActiveCamera;

        private void OnEnable()
        {
            GameManager.OnPause += ActivateCloseCamera;
            GameManager.OnResume += DesactivateCloseCamera;
        }

        private void OnDisable()
        {
            GameManager.OnPause -= ActivateCloseCamera;
            GameManager.OnResume -= DesactivateCloseCamera;
        }

        private void ActivateCloseCamera()
        {
            _pauseCvm.gameObject.SetActive(true);
        }

        private void DesactivateCloseCamera()
        {
            _pauseCvm.gameObject.SetActive(false);
        }
    }
}