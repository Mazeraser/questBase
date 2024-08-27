using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Services.SaveSystem
{
    public interface ISavable
    {
        void SaveData();
        void LoadData();
        void ResetData();
    }
}
    
