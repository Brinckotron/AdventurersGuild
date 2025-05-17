using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : Singleton<InputHandler>
{
    private GameManager gameManager;
    private Camera mainCamera;
    private SelectionManager selectionManager;

    protected override void OnAwake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        mainCamera = Camera.main;
        selectionManager = SelectionManager.Instance;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        if (Mouse.current.position.ReadValue().x < Screen.width * 0.75f &&
            Mouse.current.position.ReadValue().y < Screen.height * 0.861f &&
            Mouse.current.position.ReadValue().y > Screen.height * 0.176f &&
            !gameManager.GamePauseMenuOpen &&
            gameManager.ActiveMainTab == "guild")
        {
            // Check if we clicked on a selectable object
            var selectable = rayHit.collider.GetComponent<ISelectableObject>();
            if (selectable != null)
            {
                //Regular selection
                selectionManager.SelectObject(selectable);
            }
            else
            {
                // If we clicked on nothing selectable, clear the selection
                selectionManager.ClearSelection();
            }
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        gameManager.ShowPauseMenu();
    }

    public void OnToggleMultiSelect(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        selectionManager.ToggleMultiSelect(!selectionManager.IsMultiSelectEnabled);
    }
}
