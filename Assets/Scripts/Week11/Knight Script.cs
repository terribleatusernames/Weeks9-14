using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
public class KnightScript : MonoBehaviour
{
    public AudioSource audioSource;
    public float speed;
    public Animator knightAnimator;
    float xMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xMovement, 0, 0) * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    { 
        Vector2 moveDirection = context.ReadValue<Vector2>();
        xMovement = moveDirection.x;

        bool isRunning = xMovement != 0;

        knightAnimator.SetBool("isRunning", isRunning);
    }

    public void OnFootstep()
    {
        audioSource.Play();
    }

}
