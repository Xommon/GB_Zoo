using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector2 input;
    private Rigidbody2D rb;
    public GameObject interactTrigger;
    public float interactDistance;
    private bool facingRight = false;

    public Vector2 lastMoveDir = Vector2.down;
    public Image textbox;

    public Sprite[] walkDownFrames;
    public Sprite[] walkUpFrames;
    public Sprite[] walkLeftFrames;
    private SpriteRenderer sr;

    private float frameTimer;
    private int frameIndex;
    public float frameRate = 0.2f; // Seconds per frame

    private string lastDir = "down";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        frameIndex = 1;
    }

    void Update()
    {
        // Stop movement and animation if textbox is open
        if (textbox.enabled)
        {
            return;
        }

        // Get movement input
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Move the player
        Vector3 movement = new Vector3(input.x, input.y, 0) * moveSpeed * Time.deltaTime;
        transform.position += movement;

        // Animate movement
        HandleAnimation(input);

        // Update last move direction only if moving
        if (input.sqrMagnitude > 0.01f)
        {
            lastMoveDir = input.normalized;
        }

        // Update interactTrigger offset to always be in move direction
        if (interactTrigger != null)
        {
            interactTrigger.transform.localPosition = lastMoveDir * interactDistance;
        }
    }

    void HandleAnimation(Vector2 input)
    {
        if (input.sqrMagnitude > 0.01f)
        {
            // Advance 4-frame animation
            frameTimer += Time.deltaTime;
            if (frameTimer >= frameRate)
            {
                frameTimer = 0f;
                frameIndex = (frameIndex + 1) % 4;
            }
    
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                lastDir = "left";
                facingRight = input.x > 0;
                sr.flipX = facingRight;
                sr.sprite = walkLeftFrames[frameIndex];
            }
            else if (input.y > 0)
            {
                lastDir = "up";
                sr.flipX = false;
                sr.sprite = walkUpFrames[frameIndex];
            }
            else
            {
                lastDir = "down";
                sr.flipX = false;
                sr.sprite = walkDownFrames[frameIndex];
            }
        }
        else
        {
            // Idle – set frame 1
            frameIndex = 1;
            frameTimer = 0f;
    
            switch (lastDir)
            {
                case "up":
                    sr.sprite = walkUpFrames[1];
                    sr.flipX = false;
                    break;
                case "down":
                    sr.sprite = walkDownFrames[1];
                    sr.flipX = false;
                    break;
                case "left":
                    sr.sprite = walkLeftFrames[1];
                    sr.flipX = facingRight;
                    break;
            }
        }
    }
}