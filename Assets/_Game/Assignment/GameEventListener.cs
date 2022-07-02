using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.GameEvents
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent _gameEvent;
        //[SerializeField] private UnityEvent _response;

        [SerializeField] private GameObject player;
        [SerializeField] private Camera cam;
        
        private void OnEnable()
        {
            _gameEvent.Register(this);
        }

        private void OnDisable()
        {
            _gameEvent.Unregister(this);
        }

        public void OnEventRaised()
        {
            //_response?.Invoke();
            Vector3 screenPos = cam.WorldToScreenPoint(transform.position);
            screenPos = new Vector3(ScreenWrap(screenPos.x, cam.pixelWidth), ScreenWrap(screenPos.y, cam.pixelHeight), screenPos.z);
            transform.position = cam.ScreenToWorldPoint(screenPos);
        }

        private float ScreenWrap(float pos, float screenSize)
        {
            if(pos < 0)
            {
                pos += screenSize;
            }
            else
            {
                pos %= screenSize;
            }

            return pos;
        }

    }
}
