using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : Singleton<SelectionManager>
{
    private List<ISelectable> selectedObjects = new List<ISelectable>();
    private bool isMultiSelectEnabled = false;

    public void ToggleMultiSelect(bool enable)
    {
        isMultiSelectEnabled = enable;
        if (!enable && selectedObjects.Count > 1)
        {
            // If multi-select is disabled and we have multiple selections,
            // keep only the last selected object
            var lastSelected = selectedObjects[selectedObjects.Count - 1];
            ClearSelection();
            SelectObject(lastSelected);
        }
    }

    public void SelectObject(ISelectable selectable)
    {
        if (!isMultiSelectEnabled)
        {
            ClearSelection();
        }

        if (!selectedObjects.Contains(selectable))
        {
            selectable.OnSelected();
            selectedObjects.Add(selectable);
        }
    }

    public void DeselectObject(ISelectable selectable)
    {
        if (selectedObjects.Contains(selectable))
        {
            selectable.OnDeselected();
            selectedObjects.Remove(selectable);
        }
    }

    public void ClearSelection()
    {
        foreach (var selectable in selectedObjects)
        {
            selectable.OnDeselected();
        }
        selectedObjects.Clear();
    }

    public List<ISelectable> GetSelectedObjects()
    {
        return new List<ISelectable>(selectedObjects);
    }

    public bool IsSelected(ISelectable selectable)
    {
        return selectedObjects.Contains(selectable);
    }
}