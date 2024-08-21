using Codebase.Libraries.Stats;
using Codebase.UI;
using System;
using UnityEngine;

namespace Codebase.Services.Reward
{
    public class GiveComponent : MonoBehaviour
    {
        public static event Action<ItemStats,bool> GiveItemEvent;

        public void Give(ItemStats item, bool showInventory)
        {
            GiveItemEvent?.Invoke(item, showInventory);//inventory catch this event and add items
        }
    }
}