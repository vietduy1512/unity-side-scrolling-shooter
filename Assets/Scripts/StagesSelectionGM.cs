using UnityEngine;
using System.Collections;

public class StagesSelectionGM : MonoBehaviour {

	GameObject UIMenu;

	public void StartStages(int level)
	{
		UIMenu = GameObject.Find ("UIMenu");
		UIMenu.GetComponent<StartOptions> ().StartStages (level);
	}
}
