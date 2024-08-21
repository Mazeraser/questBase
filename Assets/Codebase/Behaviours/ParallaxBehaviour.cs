using UnityEngine;

namespace Codebase.Behaviours
{
    public class ParallaxBehaviour : MonoBehaviour
    {
        private Transform _followingTarget;
        [SerializeField, Range(-1f, 1f)]
        private float _paralaxStrenght = 0.1f;
        private Vector3 _targetPreviousPosition;
        [SerializeField]
        private bool _disableVerticalParalax;


        private void Start()
        {
            if (!_followingTarget)
            {
                _followingTarget = Camera.main.transform;
            }

            _targetPreviousPosition = _followingTarget.position;
        }

        private void Update()
        {
            var delta = _followingTarget.position - _targetPreviousPosition;

            if (_disableVerticalParalax)
            {
                delta.y = 0;
            }

            _targetPreviousPosition = _followingTarget.position;

            transform.position += delta * _paralaxStrenght;
        }
    }
}