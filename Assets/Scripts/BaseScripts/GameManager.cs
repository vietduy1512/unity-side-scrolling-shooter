using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject mainMenuUI;
    public GameObject stageSelection;
    public GameObject livesUI;
    public GameObject GameOver;
    public GameObject Stage01;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
        Stage01,
    }

    GameManagerState GMState;

	// Use this for initialization
	void Start () {
        GMState = GameManagerState.Opening;
        mainMenuUI.SetActive(true);
	}
	
	// Function to update the game manager state
	void UpdateGameManagerState() {
	    switch(GMState)
        {
            case GameManagerState.Opening:

                //Hide game over + Lives
                GameOver.SetActive(false);
                livesUI.SetActive(false);

                //Set play button visible (active)
                mainMenuUI.SetActive(true);

                break;
            case GameManagerState.Gameplay:

                //hide play button on game play state
                mainMenuUI.SetActive(false);
                // Show Stage Seclection
                stageSelection.SetActive(true);

                break;
            case GameManagerState.GameOver:

                //Stop enemy spawner
                /*Already STOP when _gameObject.SetActive(false)_ in __PlayerSpawner__ above*/

                //Display game over
                GameOver.SetActive(true);
                //Change game manager state to Opening state
                Invoke("ChangeToOpeningState", 8f);

                break;
            case GameManagerState.Stage01:
                ActiveStage();
                Stage01.SetActive(true);
                break;
        }
	}

    //Funtion to set the game manager state
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    //The Play Button
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }

    public void ActiveStage()
    {
        //Turn on Lives
        livesUI.SetActive(true);
        
        stageSelection.SetActive(false);
    }
    
    // STAGEs for the Game
    public void StartStage01()
    {
        GMState = GameManagerState.Stage01;
        UpdateGameManagerState();
    }
}
