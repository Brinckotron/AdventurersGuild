using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : Singleton<InputHandler>
{
    private GameManager gameManager;
    private Camera mainCamera;
    private TimeManager timeManager;
    private bool gamePaused;

    protected override void OnAwake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        timeManager = FindFirstObjectByType<TimeManager>();
        mainCamera = Camera.main;
    }


    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        if (Mouse.current.position.ReadValue().x < Screen.width * 0.75f &&
            Mouse.current.position.ReadValue().y < Screen.height * 0.861f &&
            Mouse.current.position.ReadValue().y > Screen.height * 0.176f &&
            gameManager.ActiveMainTab == "guild")
        {
            Debug.Log("Lol");
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        if (!gamePaused)
        {
            gamePaused = true;
            timeManager.PauseTime();
            Debug.Log("Pause Game");
        }
        else
        {
            gamePaused = false;
            timeManager.ResumeTime();
            Debug.Log("Resume Game");
        }
    }
    
   
}
