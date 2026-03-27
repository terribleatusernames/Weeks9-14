using UnityEngine;

using UnityEngine.Events;
using UnityEngine.InputSystem;
public class Detector : MonoBehaviour
{
    public UnityEvent onHover;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = context.ReadValue<Vector2>();
        
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0f; 

        bool isHovered = spriteRenderer.bounds.Contains(worldPosition);

        if (isHovered)
        {
                onHover.Invoke();
        }
    }
}
