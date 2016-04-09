using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIStartController : MonoBehaviour
{
	public GameObject[] Menus = { };
	private Transform canvasParent;
	private GameObject MenuPanel;
	private Stack<GameObject> PanelStack = new Stack<GameObject> ();

	// Use this for initialization
	void Start ()
	{
		if (!canvasParent) {
			canvasParent = GameObject.Find ("Canvas").transform;
		}
		if (Menus.Length > 0) {
			if (!MenuPanel) {
				MenuPanel = Instantiate (Menus [0]) as GameObject;
				MenuPanel.transform.SetParent (canvasParent, false);
				// Buttonklick dran hängen
				ButtonAddListener ();
			}	
		} else {
			Debug.Log ("Kein Menü angebunden");
		}
	}

	void ButtonAddListener () {
		// Buttonklick dran hängen
		Button[] lButtons = MenuPanel.GetComponentsInChildren<Button> ();
		foreach (Button lButton in lButtons) {
			UIButtonData lButtonData = lButton.GetComponent<UIButtonData> ();

			switch (lButtonData.mode) {
			case UIButtonData.Mode.OpenPanel:
				//OpenPanel = 0,
				lButton.onClick.AddListener (delegate {ClickEventSwitchPanel (lButtonData.name, lButtonData.Object);});
				break;
			case UIButtonData.Mode.StartLevel:
				//StartLevel = 1,
				lButton.onClick.AddListener (delegate {ClickEvent (lButtonData.name, lButtonData.Object);});
				break;
			case UIButtonData.Mode.Back:
				//Back = 2,
				lButton.onClick.AddListener (delegate {ClickEventBack (lButtonData.name, lButtonData.Object);});
				break;
			case UIButtonData.Mode.MainMenu:
				//MainMenu = 3,
				lButton.onClick.AddListener (delegate {ClickEvent (lButtonData.name, lButtonData.Object);});
				break;
			default:
				Debug.Log ("Klickmodus nicht verfügbar");
				break;
			}
		}
	}

	void ClickEvent (string argument1, string argument2) {
		Debug.Log ("ClickEvent " + argument1 + ", " + argument2);
	}

	void ClickEventSwitchPanel (string ButtonName, string ObjectName){
		int i = 0, lIndex = 0;

		if (!string.IsNullOrEmpty (ObjectName)) {
			foreach (GameObject lMenu in Menus) {
				if (lMenu.name == ObjectName) {
					lIndex = i;
				}
				i++;
			}

			if (MenuPanel) {
				MenuPanel.SetActive (false);
				PanelStack.Push (MenuPanel);

				MenuPanel = Instantiate (Menus [lIndex]) as GameObject;
				MenuPanel.transform.SetParent (canvasParent, false);
				// Buttonklick dran hängen
				ButtonAddListener ();
			}  else {
				MenuPanel = Instantiate (Menus [0]) as GameObject;
				MenuPanel.transform.SetParent (canvasParent, false);
			}
		} else {
			Debug.Log ("Fehler: Objektname fehlt!");
		}
	}

	void ClickEventBack (string ButtonName, string ObjectName){
		if (PanelStack.Count == 0) {
			// nichts tun, geht nicht weiter zurück
		} else {
			Destroy (MenuPanel);
			MenuPanel = PanelStack.Pop ();
			MenuPanel.SetActive (true);
		}
	}

	public void ApplExit ()
	{
		Application.Quit();
	}
}
