using Codebase.Character;
using UnityEngine;

namespace Codebase.Components
{
	public class CharacterComponent : MonoBehaviour
	{
		[field: SerializeField]
		public CharacterMove CharacterMove { get; private set; }
	}
}