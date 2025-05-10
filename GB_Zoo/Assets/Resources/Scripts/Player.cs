using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector2 input;
    private Rigidbody2D rb;
    public GameObject interactTrigger;

    public Vector2 lastMoveDir = Vector2.down; // Default facing direction

    void Update()
    {
        // Get movement input
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Initialize Rigidbody if not already cached
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        // Move the player
        Vector3 movement = new Vector3(input.x, input.y, 0) * moveSpeed * Time.deltaTime;
        transform.position += movement;

        // Update last move direction only if moving
        if (input.sqrMagnitude > 0.01f)
        {
            lastMoveDir = input.normalized;
        }

        // Update interactTrigger offset to always be 0.15 units away in the direction of movement
        if (interactTrigger != null)
        {
            interactTrigger.transform.localPosition = lastMoveDir * 0.15f;

        }
    }
}
