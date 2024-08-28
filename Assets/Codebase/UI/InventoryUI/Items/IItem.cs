using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Codebase.UI.InventoryUI.Items
{
    public interface IItem
    {
        void Activation();
        void Deactivation();
    }
}