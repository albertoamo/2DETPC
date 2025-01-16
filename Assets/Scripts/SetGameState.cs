using UnityEngine;

public class SetGameState : MonoBehaviour
{
    public GameStateManager.GameState targetState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // This is slow, use singleton pattern instead
        //GameStateManager statemanager = FindFirstObjectByType<GameStateManager>();
        //statemanager.ChangeState(targetState);

        // Use this instead
        GameStateManager.INSTANCE.ChangeState(targetState);
    }
}
