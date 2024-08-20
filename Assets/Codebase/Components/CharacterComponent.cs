using Codebase.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
	[field: SerializeField]
	public CharacterMove CharacterMove { get; private set; }
}
