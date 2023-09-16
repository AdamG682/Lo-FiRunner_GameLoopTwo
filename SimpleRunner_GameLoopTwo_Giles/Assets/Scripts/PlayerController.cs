using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{

    Timer timer;

    [SerializeField] private float horizontalSpeed = 2.0f;
    [SerializeField] private float setSpeed = 1;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] GameObject gameOverInterface;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    bool alive = true;

    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        timer = GameObject.FindObjectOfType<Timer>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.action.triggered;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (!alive) return;

        Vector3 forwardMove = transform.forward * setSpeed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * movementInput * horizontalSpeed * Time.fixedDeltaTime;
        controller.Move(forwardMove + horizontalMove);

        if (jumped && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        if(transform.position.y < -5)
        {
            Die();
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Die()
    {
        alive = false;
        timer.timerOn = false;
        gameOverInterface.SetActive(true);
        Debug.Log("Dead");
    }
}
