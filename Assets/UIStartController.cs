using UnityEngine;

//using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIStartController : MonoBehaviour
{
	public GameObject Menu1 ;
	public GameObject Menu2 ;

	private GameObject Menue1;
	private Transform canvasParent;

	// Use this for initialization
	void Start ()
	{
		if (!canvasParent) {
			canvasParent = GameObject.Find("Canvas").transform;
			if (canvasParent) {
				Menue1 = Instantiate (Menu1, canvasParent.position, canvasParent.rotation) as GameObject;
				Menue1.transform.SetParent (canvasParent, false);
			}
		}
	}

	/*void UpdatePlayerDrowpdown ()
	{
		string lName = PlayerPrefs.GetString ("PlayerName", "Winston");
		int i = 0, lIndex = 0;
		m_DropdownPlayer.ClearOptions ();
		List<string> lPlayers = new List<string> ();
		foreach (Player lP in AllLevels.Get().data.players) {
			lPlayers.Add (lP.name);
			if (lP.name == lName) {
				lIndex = i;
			}
			i++;
		}
		m_DropdownPlayer.AddOptions (lPlayers);
		m_DropdownPlayer.value = lIndex;
	}*/

	// Update is called once per frame
	void Update ()
	{
	}

	public void ButtonStorymodus ()
	{
		Debug.Log ("Button klick");
	}

	public void ButtonEinstellungen ()
	{
		Application.Quit();
	}
}
