using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Services.Gate
{
    public class GateParent<T> : MonoBehaviour
    {
        [SerializeField]
        protected T[] _requiredItems;

        private enum GateType
        {
            destroyable = 0,
            colliderActivator = 1,
        }
        [SerializeField]
        private GateType _gateType;

        protected virtual void OpenGate()
        {
            switch ((int)_gateType)
            {
                case 0:
                    Destroy(this.gameObject);
                    break;
                case 1:
                    GetComponent<Collider2D>().enabled = !GetComponent<Collider2D>().enabled;
                    Destroy(this);
                    break;
            }
        }
    }
}