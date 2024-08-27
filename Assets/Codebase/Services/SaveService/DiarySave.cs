using Codebase.Infrastructure.States;
using Codebase.Infrastructure;
using Codebase.Services.DiarySystem;
using Codebase.Services.QuestSystem;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Codebase.Services.QuestSystem.Quests;
using Fungus;

namespace Codebase.Services.SaveSystem
{
    public class DiarySave : ISavable
    {
        private DiaryQuest _diary;

        private DiarySave(DiaryQuest diary)
        {
            _diary = diary;
            NewGameState.NewGameStarted += ResetData;
            ContinueGameState.ReturnDataEvent += LoadData;
            TriggerSceneTransition.SaveGameData += SaveData;
        }

        public void SaveData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath
              + "/MyDiaryData.dat");
            bf.Serialize(file, _diary.QuestDatas);
            file.Close();
            Debug.Log("Diary data saved!");
        }
        public void LoadData()
        {
            if (File.Exists(Application.persistentDataPath
                + "/MyDiaryData.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file =
                  File.Open(Application.persistentDataPath
                  + "/MyDiaryData.dat", FileMode.Open);
                QuestData[] data = (QuestData[])bf.Deserialize(file);
                file.Close();

                _diary.DeleteAll();
                _diary.QuestDatas = data;
                foreach (QuestData quest in data)
                {
                    QuestScriptParser.DeserializeData(quest.FilePath);
                }
                Debug.Log("Diary data loaded!");
            }
            else
                Debug.LogError("There is no diary data!");
        }
        public void ResetData()
        {
            if (File.Exists(Application.persistentDataPath
                + "/MyDiaryData.dat"))
            {
                File.Delete(Application.persistentDataPath
                  + "/MyDiaryData.dat");
                Debug.Log("Diary data reset complete!");
            }
            else
                Debug.LogError("No save diary data to delete.");
        }
    }
}