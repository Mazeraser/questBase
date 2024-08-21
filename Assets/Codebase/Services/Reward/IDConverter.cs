using Codebase.Libraries;
using Codebase.Libraries.Stats;
using Codebase.UI;
using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Codebase.Services.Reward
{
    public class IDConverter : MonoBehaviour
    {
        [SerializeField] private ItemLibrary itemArray;

        public void Convert(int id, bool showInventory)
        {
            foreach (ItemStats item in itemArray.ItemStats)
            {
                if (item.ID == id)
                {
                    GetComponent<GiveComponent>().Give(item, showInventory);
                    break;
                }
            }
        }
    }
}