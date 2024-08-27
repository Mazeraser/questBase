using Codebase.Infrastructure.States;
using Codebase.Infrastructure;
using Codebase.Libraries.Stats;
using Codebase.Services.InventorySystem;
using Codebase.Services.SceneLoader;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Codebase.Services.SaveSystem
{
    public class SceneDataSave : ISavable
    {
        private SceneTransition _sceneTransition;

        public SceneDataSave(SceneTransition sceneTransition)
        {
            _sceneTransition = sceneTransition;
            NewGameState.NewGameStarted += ResetData;
            ContinueGameState.ReturnDataEvent += LoadData;
            TriggerSceneTransition.SaveGameData += SaveData;
        }

        public void SaveData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath
              + "/MySceneData.dat");

            bf.Serialize(file, _sceneTransition.data);
            file.Close();
            Debug.Log("Scene data saved!");
        }
        public void LoadData()
        {
            if (File.Exists(Application.persistentDataPath
              + "/MySceneData.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file =
                  File.Open(Application.persistentDataPath
                  + "/MySceneData.dat", FileMode.Open);

                _sceneTransition.data = (SceneTransitionData)bf.Deserialize(file);
                file.Close();
                Debug.Log("Scene data loaded!");
            }
            else
                Debug.LogError("There is no inventory data!");
        }
        public void ResetData()
        {
            if (File.Exists(Application.persistentDataPath
                + "/MySceneData.dat"))
            {
                File.Delete(Application.persistentDataPath
                  + "/MySceneData.dat");
                Debug.Log("Scene data reset complete!");
            }
            else
                Debug.LogError("No scene data to delete.");
        }
    }
}