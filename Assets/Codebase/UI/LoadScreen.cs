using UnityEngine;
using TMPro;

public class LoadScreen : MonoBehaviour
{
	[SerializeField]
	private Canvas _canvas;
    [SerializeField]
    private TMP_Text _loader;

	private void Start()
	{
		Disable();
	}

	public void Enable()
	{
		_canvas.enabled = true;
	}

	public void Disable()
	{
		_canvas.enabled = false;
	}
}
