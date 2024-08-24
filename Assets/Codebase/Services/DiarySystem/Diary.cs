using System;
using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Services.DiarySystem
{
    public abstract class Diary<T> : MonoBehaviour,IDiary<T>
    {
        public static event Action<T> NewObjectAddedToDiary;

        [SerializeField]
        private protected List<T> _objectList;

        public virtual void Start()
        {
            _objectList = new List<T>();
        }
        public virtual void Update()
        {
        }

        public virtual void Add(T obj)
        {
            _objectList.Add(obj);
            NewObjectAddedToDiary?.Invoke(obj);
        }
        public T[] Get()
        {
            return _objectList.ToArray();
        }
        public virtual void DeleteEmpty(ref List<T> objects)
        {
            
        }
    }
}
