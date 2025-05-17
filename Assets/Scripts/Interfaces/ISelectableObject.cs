using UnityEngine;

public interface ISelectableObject
{
    void OnSelected();
    void OnDeselected();
    bool IsSelected { get; }
    GameObject gameObject { get; }
}