using Codebase.Services.Input;
using UnityEngine;
using Zenject;

namespace Codebase.UI.DiaryUI
{
    public abstract class Page<T> : MonoBehaviour
    {
        [SerializeField]
        private protected GameObject _objectPrefab;

        protected InputService _input;

        protected bool _visualised;

        [Inject]
        private void Construct(InputService input)
        {
            _input = input;
        }

        public virtual void Start()
        {
            ClearUI();
        }


        public virtual void ClearUI()
        {
            foreach(Transform child in transform.GetComponentInChildren<Transform>())
            {
                Destroy(child.gameObject);
            }
            _visualised = false;
        }

        public virtual  void AddObjectToPage(T obj) { return; }

        public virtual void VisualizeDiary()
        {
            Debug.Log("Visualising on" + name + "not realized");
            return;
        }

        public virtual void ShowPage()
        {
            VisualizeDiary();
        }
        public virtual void HidePage()
        {
            ClearUI();
        }

    }
}
