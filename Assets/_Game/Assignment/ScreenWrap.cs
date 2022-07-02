using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.GameEvents
{
    public class ScreenWrap : MonoBehaviour
    {
        public GameEvent Event;

        private void OnTriggerExit2D(Collider2D collision)
        {
            Event.Raise();
        }
    }
}
