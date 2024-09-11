using UnityEngine;
using UnityEngine.Events;



[RequireComponent (typeof(PlayerMovement))]
[RequireComponent (typeof (Shooter))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Shooter shooter;
    private Animator animator;


    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
    public const string JUMP = "Jump";
    public const string FIRE_1 = "Fire1";


    [SerializeField] private UnityEvent EscapePressed;

    private bool canBeControlled = true;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis(HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(JUMP);

        if (canBeControlled && Input.GetButtonDown(FIRE_1))
        {
            shooter.Shoot(horizontalDirection);
            animator.SetTrigger("isQuickAttacking");
        }

        if (canBeControlled)
        {
            playerMovement.Move(horizontalDirection, isJumpButtonPressed);
        }



        if (horizontalDirection == 0)
        {
            animator.SetBool("isRunning", false);
        }

        else if (canBeControlled && Mathf.Abs(horizontalDirection) > 0.000f)
        {
            animator.SetBool("isRunning", true);
        }


        if (canBeControlled && Input.GetKeyDown(KeyCode.Escape))
        {
            EscapePressed.Invoke();
        }
    }

    public void ChangePossibilityControl()
    {
        canBeControlled = !canBeControlled;
    }
}
