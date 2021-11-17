using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	public Animator animator;
	[SerializeField] private float m_JumpForce = 250f;							// Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching
	[SerializeField] private Rigidbody2D rigid_Body;

	[Header("For WallSliding")]
	[SerializeField] float wallSlideSpeed;
	[SerializeField] LayerMask wallLayer;
	[SerializeField] Transform wallCheckPoint;
	[SerializeField] Vector2 wallCheckSize;
	private bool isTouchingWall;
	private bool isWallSliding;

	[Header("For WallJumping")]
	[SerializeField] float walljumpforce;
	[SerializeField] Vector2 walljumpAngle;
	[SerializeField] float walljumpDirection = -1;
	public bool isJump = false;

	private bool isLadder;
	private bool isClimbing = false;
	private float climbSpeed = 5f;
	private float vertical;
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

	public void isJumpChange(bool jump_bool)
    {
		isJump = jump_bool;
    }

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		walljumpAngle.Normalize();
		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

    private void Update()
    {
		vertical = Input.GetAxis("Vertical");
		if (isLadder && Mathf.Abs(vertical) > 0f) isClimbing = true;
    }

    private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		isTouchingWall = Physics2D.OverlapBox(wallCheckPoint.position, wallCheckSize, 0, wallLayer);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}

		if (isTouchingWall && !m_Grounded && rigid_Body.velocity.y < 0)
		{
			animator.SetBool("isWallSlide", true);
			isWallSliding = true;
		}
		else
		{
			animator.SetBool("isWallSlide", false);
			isWallSliding = false;
		}

		if (isWallSliding) rigid_Body.velocity = new Vector2(rigid_Body.velocity.x, -wallSlideSpeed);

		if (isWallSliding && isTouchingWall && isJump)
		{
			rigid_Body.AddForce(new Vector2(walljumpforce * walljumpAngle.x * walljumpDirection, walljumpforce * walljumpAngle.y), ForceMode2D.Impulse);
			Flip();
			isJump = false;
		}

		if (isClimbing)
		{
			m_JumpForce = 0f;
			rigid_Body.velocity = new Vector2(rigid_Body.velocity.x, vertical * climbSpeed);
		}
		else m_JumpForce = 250f;
	}

	// Gizmos is graphical renderer that shows in scene for debugging purposes (detect colliding, interact, etc). 
	// Something like gc check atas dan gc check bawah.
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(m_GroundCheck.position, k_GroundedRadius);
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(m_CeilingCheck.position, k_CeilingRadius);
		Gizmos.color = Color.green;
		Gizmos.DrawCube(wallCheckPoint.position, wallCheckSize);
	}

	public void Move(float move, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				// Reduce the speed by the crouchSpeed multiplier
				move *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.CompareTag("Ladder")) isLadder = true;
    }

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Ladder"))
		{
			isLadder = false;
			isClimbing = false;
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;
		walljumpDirection *= -1;
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}