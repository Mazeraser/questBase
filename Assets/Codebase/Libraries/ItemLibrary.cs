using System.Collections.Generic;
using Codebase.Libraries.Stats;
using UnityEngine;

namespace Codebase.Libraries
{
    [CreateAssetMenu(fileName = "Item Data", menuName = "Create Item Library", order = 0)]
    public class ItemLibrary : ScriptableObject
    {
        public List<ItemStats> ItemStats;
    }
}