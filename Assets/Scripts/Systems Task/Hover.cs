using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Hover : MonoBehaviour
{
 
    private SpriteRenderer spriteRenderer;
    public UnityEvent Delete;
    public UnityEvent Show;
    public UnityEvent Unshow;
    bool isHovered;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    
    void Update()
    {
        
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = context.ReadValue<Vector2>();

        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        isHovered = spriteRenderer.bounds.Contains(worldPosition);

        if (isHovered)
        {
            Show.Invoke();
        }
        else
        {
            Unshow.Invoke();
        }
    }

    public void Click(InputAction.CallbackContext context)
    {
        if (context.performed && isHovered)
        {
            Delete.Invoke();
        }
    }
}
