using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpForce = 5f;

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        // Freeze rotation around X and Z axes
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // Get the forward direction of the camera in world space
        Vector3 forwardDirection = Camera.main.transform.forward;
        forwardDirection.y = 0f; // Project onto the XZ plane
        forwardDirection.Normalize();

        // Get input from A and D keys
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement direction relative to the camera's forward direction
        Vector3 inputDirection = forwardDirection * 0f + Camera.main.transform.right * horizontalInput; // Set verticalInput to 0
        inputDirection.Normalize();

        // Calculate movement based on input
        Vector3 movement = new Vector3(inputDirection.x, 0f, inputDirection.z);

        // Apply force to the Rigidbody for movement
        MovePlayer(movement);

        // Handle jumping
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void MovePlayer(Vector3 movement)
    {
        // Apply force to the Rigidbody for movement
        rb.AddForce(movement * moveSpeed);
    }

    void Jump()
    {
        // Apply the jump force
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
