using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Behaviours
{
    public class LightningObject : MonoBehaviour
    {
        [SerializeField] private GameObject outlineObject;
        private void OnMouseEnter()
        {
            outlineObject?.SetActive(true);
        }
        private void OnMouseExit()
        {
            outlineObject?.SetActive(false);
        }
    }
}
    
