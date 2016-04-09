using UnityEngine;
using System.Collections;

public class UIButtonData : MonoBehaviour {

	public enum Mode
	{
		OpenPanel = 0,
		StartLevel = 1,
		Back = 2,
		MainMenu = 3,
	}
	public Mode mode = Mode.OpenPanel;
	public string Object;
}