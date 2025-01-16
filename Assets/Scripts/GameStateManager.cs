using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Gamestate pattern
public class GameStateManager : MonoBehaviour
{
    public static GameStateManager INSTANCE;

    [Serializable]
    public enum GameState
    {
        GAMEPLAY,
        MAINMENU,
        WIN,
        OVER,
        PAUSE
    }

    public GameState currentState;

    // Start is called before the first frame update
    void Start()
    {
        INSTANCE = this;
    }

    void Update()
    {
        OnUpdateState(currentState);
    }

    public void ChangeState(int state)
    {
        ChangeState((GameState)state);
    }

    // Method to change current gamestate
    public void ChangeState(GameState state)
    {
        Debug.Log("Gamestate changed: " + state);
        OnExitState(currentState);

        currentState = state;

        OnEnterState(currentState);
    }

    public void OnUpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.GAMEPLAY:
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        ChangeState(GameState.PAUSE);
                    }
                }
                break;
            case GameState.MAINMENU:
                break;
            case GameState.WIN: break;
            case GameState.OVER:
                break;
            case GameState.PAUSE:
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        ChangeState(GameState.GAMEPLAY);
                    }
                }
                break;
            default: break;
        }
    }

    public void OnEnterState(GameState state)
    {
        switch(state)
        {
            case GameState.GAMEPLAY:
                {            
                    UIHealth healthUI = FindObjectOfType<UIHealth>(true);
                    healthUI.gameObject.SetActive(true);
                }
                break;
            case GameState.MAINMENU:
                {
                    UIMainMenu menu = FindObjectOfType<UIMainMenu>(true);
                    menu.gameObject.SetActive(true);
                }
                break;
            case GameState.WIN: break;
            case GameState.OVER:
                {
                    UIOverMenu menu = FindObjectOfType<UIOverMenu>(true);
                    menu.gameObject.SetActive(true);

                    Time.timeScale = 0;
                }
                break;
            case GameState.PAUSE:
                {
                    UIPauseMenu menu = FindObjectOfType<UIPauseMenu>(true);
                    menu.gameObject.SetActive(true);

                    Time.timeScale = 0;
                }
                break;
            default: break;
        }
    }

    public void OnExitState(GameState state)
    {
        switch (state)
        {
            case GameState.GAMEPLAY:
                {
                    {
                        UIHealth healthUI = FindObjectOfType<UIHealth>(true);
                        healthUI.gameObject.SetActive(false);
                    }
                }
                break;
            case GameState.MAINMENU:
                {
                    UIMainMenu menu = FindObjectOfType<UIMainMenu>(true);
                    menu.gameObject.SetActive(false);
                }
                break;
            case GameState.WIN: break;
            case GameState.OVER:
                {
                    UIOverMenu menu = FindObjectOfType<UIOverMenu>(true);
                    menu.gameObject.SetActive(false);

                    Time.timeScale = 1;
                }
                break;
            case GameState.PAUSE:
                {
                    UIPauseMenu menu = FindObjectOfType<UIPauseMenu>(true);
                    menu.gameObject.SetActive(false);

                    Time.timeScale = 1;
                }
                break;
            default: break;
        }
    }

    public void ChangeToGameplay()
    {
        LevelManager.INSTANCE.LoadLevel("spmap_gp1");

        ChangeState(GameState.GAMEPLAY);
    }

    public void ChangeToGameplayImmediate()
    {
        ChangeState(GameState.GAMEPLAY);
    }

    public void ChangeToMainMenu()
    {
        LevelManager.INSTANCE.LoadLevel("spmap_mainmenu");

        ChangeState(GameState.MAINMENU);
    }

    public void ChangeToPause()
    {
        ChangeState(GameState.PAUSE);
    }

    public void ChangeToOver()
    {
        ChangeState(GameState.OVER);
    }

    public void ChangeToWin()
    {
        ChangeState(GameState.WIN);
    }
}
