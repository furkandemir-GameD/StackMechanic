using UnityEngine.Events;

public class GameManager : MonoSingleton<GameManager>
{
    public static UnityAction OnGameStart;
    public static UnityAction OnGameFail;
    public static UnityAction OnGameWin;

    public static UnityAction<GameStates> OnGameStateChange;

    private GameStates currentState = GameStates.LoadingLevel;
    public GameStates CurrentState
    {
        get
        {
            return currentState;
        }
        set
        {
            currentState = value;
            OnGameStateChange?.Invoke(value);
        }
    }

    private void Start()
    {
        CurrentState = GameStates.MainMenu;
        OnGameStateChange?.Invoke(GameStates.MainMenu);
    }

    public void StartGame()
    {
        OnGameStart?.Invoke();
        CurrentState = GameStates.GamePlay;
    }

    public void FailGame()
    {
        OnGameFail?.Invoke();
        CurrentState = GameStates.GameFail;
    }

    public void WinGame()
    {
        OnGameWin?.Invoke();
        CurrentState = GameStates.GameWin;
    }

    public enum GameStates
    {
        LoadingLevel,
        MainMenu,
        GamePlay,
        GameFail,
        GameWin,
    }
}
