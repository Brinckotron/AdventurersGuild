using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : Singleton<InputHandler>
{
    private GameManager gameManager;
    private Camera mainCamera;

    protected override void OnAwake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        if (Mouse.current.position.ReadValue().x < Screen.width * 0.68f &&
            Mouse.current.position.ReadValue().y < Screen.height * 0.85f
            && gameManager.ActiveMainTab == "guild")
        {
            Debug.Log("Lol");
        }
    }

   
}
