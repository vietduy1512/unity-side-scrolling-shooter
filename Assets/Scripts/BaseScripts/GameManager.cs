using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject stageSelection;
    [SerializeField] GameObject livesUI;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject Stage01;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
        Stage01,
    }

    GameManagerState GMState;

    void Start()
    {
        GMState = GameManagerState.Opening;
        mainMenuUI.SetActive(true);
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                GameOver.SetActive(false);
                livesUI.SetActive(false);

                mainMenuUI.SetActive(true);

                break;
            case GameManagerState.Gameplay:
                mainMenuUI.SetActive(false);
                stageSelection.SetActive(true);

                break;
            case GameManagerState.GameOver:
                GameOver.SetActive(true);
                Invoke("ChangeToOpeningState", 8f);

                break;
            case GameManagerState.Stage01:
                ActiveStage();
                Stage01.SetActive(true);
                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

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
        livesUI.SetActive(true);

        stageSelection.SetActive(false);
    }

    public void StartStage01()
    {
        GMState = GameManagerState.Stage01;
        UpdateGameManagerState();
    }
}
