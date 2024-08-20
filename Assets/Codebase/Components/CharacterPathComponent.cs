using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;

namespace Codebase.Components
{
	[Serializable]
	public struct Point
	{
		public Color color;
		public string name;
		public float value;
		public SplineContainer path;
	}

	public class CharacterPathComponent : MonoBehaviour
	{
		[SerializeField]
		private List<Point> _points = new();

		private float _currentPathValue = 0f;
		private int _currentPathIndex = 0;

		public bool CanMove { get; private set; }

		public Vector3 GetPointPosition(string name)
		{
			int index = _points.FindIndex(x => x.name == name);
			float value = _points[index].value;
			float length = _points[index].path.CalculateLength();

			_currentPathValue = value;
			_currentPathIndex = index;

			return _points[_currentPathIndex].path.EvaluatePosition(value / length);
		}

		public Vector3 GetPosition(float step)
		{
			float length = _points[_currentPathIndex].path.CalculateLength();
			float nextPathValue = _currentPathValue + step;

			CanMove = nextPathValue <= length && nextPathValue >= 0f;

			_currentPathValue = Mathf.Clamp(nextPathValue, 0f, length);
        
			return _points[_currentPathIndex].path.EvaluatePosition(_currentPathValue / length);
		}

		#if UNITY_EDITOR
		private void OnValidate()
		{
			if (_points != null && _points.Count > 0)
			{
				for (int i = 0; i < _points.Count; i++)
				{
					float length = _points[i].path.CalculateLength();
					var value = _points[i].value;

					value = Mathf.Clamp(value, 0f, length);

					var point = _points[i];
					point.value = value;
					_points[i] = point;
				}
			}
		}
		private void OnDrawGizmos()
		{
			if (_points != null && _points.Count > 0)
			{
				for (int i = 0; i < _points.Count; i++)
				{
					float length = _points[i].path.CalculateLength();
					Vector3 point = _points[i].path.EvaluatePosition(_points[i].value / length);

					Gizmos.color = _points[i].color;
					Gizmos.DrawWireSphere(point, 0.2f);
					Handles.Label(point + new Vector3(-_points[i].name.Length * 0.01f, 0.25f), $"{_points[i].name}");
				}
			}
		}
		#endif
    }
}