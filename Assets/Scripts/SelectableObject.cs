using UnityEngine;

public class SelectableObject : MonoBehaviour, ISelectableObject
{
    [SerializeField] private Color selectedColor = Color.yellow;
    [SerializeField] private Color normalColor = Color.white;
    
    private SpriteRenderer spriteRenderer;
    private bool isSelected;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogWarning($"No SpriteRenderer found on {gameObject.name}. Selection highlighting will not work.");
        }
    }

    public virtual void OnSelected()
    {
        isSelected = true;
        if (spriteRenderer != null)
        {
            spriteRenderer.color = selectedColor;
        }
    }

    public virtual void OnDeselected()
    {
        isSelected = false;
        if (spriteRenderer != null)
        {
            spriteRenderer.color = normalColor;
        }
    }

    public bool IsSelected => isSelected;
} 