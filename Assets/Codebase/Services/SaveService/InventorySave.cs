using Codebase.Infrastructure;
using Codebase.Infrastructure.States;
using Codebase.Libraries.Stats;
using Codebase.Services.InventorySystem;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Codebase.Services.SaveSystem
{

    public class InventorySave : ISavable
    {
        public static Action<int[]> LoadSavedItems;

        private Inventory _inventory;

        public InventorySave(Inventory inventory)
        {
            _inventory = inventory;
            NewGameState.NewGameStarted += ResetData;
            ContinueGameState.ReturnDataEvent += LoadData;
            TriggerSceneTransition.SaveGameData += SaveData;
        }

        //TODO: add saving and loading item type
        public void SaveData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath
              + "/MyInventoryData.dat");

            bf.Serialize(file, _inventory.InventoryIDs);
            file.Close();
            Debug.Log("Inventory data saved!");
        }
        public void LoadData()
        {
            if (File.Exists(Application.persistentDataPath
              + "/MyInventoryData.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file =
                  File.Open(Application.persistentDataPath
                  + "/MyInventoryData.dat", FileMode.Open);

                int[] slots = (int[])bf.Deserialize(file);
                file.Close();
                _inventory.InventoryIDs = slots;
                Debug.Log("Inventory data loaded!");
            }
            else
                Debug.LogError("There is no inventory data!");
        }
        public void ResetData()
        {
            if (File.Exists(Application.persistentDataPath
                + "/MyInventoryData.dat"))
            {
                File.Delete(Application.persistentDataPath
                  + "/MyInventoryData.dat");
                _inventory.InventorySlots = new ItemStats[Inventory.INVENTORY_SIZE];
                Debug.Log("Inventory data reset complete!");
            }
            else
                Debug.LogError("No inventory data to delete.");
        }
    }
}
