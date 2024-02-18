using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float initialHeightOffset = 4f;
    public float initialSideOffset = 4f;
    private int currentCameraIndex = 0;
    public int CameraPositions = 5;

    public float zoomSpeed = 1f;
    public float minZoom = 1f; // Adjust these values as needed
    public float maxZoom = 5f;

    void Update()
    {
        // Check if the player is dragging an object

        // Switch camera position on 'E' key press
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchCameraPosition(true);
        }

        // Switch camera position on 'Q' key press
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchCameraPosition(false);
        }

        MoveCamera();

        // Zoom in with 'W'
        if (Input.GetKey(KeyCode.W))
        {
            ZoomCamera(-1); // Zoom in
        }

        // Zoom out with 'S'
        if (Input.GetKey(KeyCode.S))
        {
            ZoomCamera(1); // Zoom out
        }
    }

    void MoveCamera()
    {
        Vector3 playerPosition = player.position;
        Vector3 targetPosition = Vector3.zero;

        switch (currentCameraIndex)
        {
            case 0:
                targetPosition = new Vector3(playerPosition.x, playerPosition.y + initialHeightOffset, playerPosition.z);
                break;
            case 1:
                targetPosition = new Vector3(playerPosition.x + initialSideOffset, playerPosition.y, playerPosition.z);
                break;
            case 2:
                targetPosition = new Vector3(playerPosition.x - initialSideOffset, playerPosition.y, playerPosition.z);
                break;
            case 3:
                targetPosition = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z + initialSideOffset);
                break;
            case 4:
                targetPosition = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z - initialSideOffset);
                break;
        }

        transform.position = targetPosition;
        transform.LookAt(playerPosition);
    }

    void SwitchCameraPosition(bool forward)
    {
        // Toggle between camera positions
        if (forward)
        {
            currentCameraIndex = (currentCameraIndex + 1) % CameraPositions;
        }
        else
        {
            currentCameraIndex = (currentCameraIndex - 1 + CameraPositions) % CameraPositions;
        }
    }
    void ZoomCamera(int direction)
    {
        initialHeightOffset = Mathf.Clamp(initialHeightOffset + direction * zoomSpeed * Time.deltaTime, minZoom, maxZoom);
        initialSideOffset = Mathf.Clamp(initialSideOffset + direction * zoomSpeed * Time.deltaTime, minZoom, maxZoom);

        // Ensure both height and side offsets are within the valid range
        initialHeightOffset = Mathf.Clamp(initialHeightOffset, minZoom, maxZoom);
        initialSideOffset = Mathf.Clamp(initialSideOffset, minZoom, maxZoom);
    }
}
