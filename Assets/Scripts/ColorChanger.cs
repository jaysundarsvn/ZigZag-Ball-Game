using UnityEngine;

public class DynamicBackgroundAndCubeColor : MonoBehaviour
{
    private Camera cam;                    // Reference to the Camera component
    public GameObject platformPrefab;      // Reference to the platform prefab (assign in the Inspector)
    private Renderer cubeRenderer;         // Reference to the Renderer of the instantiated cube
    private Color currentCameraColor;      // The current color of the camera background
    private Color targetCameraColor;       // The target color for the camera background
    private Color currentCubeColor;        // The current color of the cube
    private Color targetCubeColor;         // The target color for the cube
    private float cameraChangeInterval = 30f; // Time interval in seconds for camera color change
    private float cubeChangeInterval = 40f;   // Time interval in seconds for cube color change
    private float cameraTimer;             // Timer to keep track of camera color change
    private float cubeTimer;               // Timer to keep track of cube color change

    void Start()
    {
        // Find the main camera using its tag and get the Camera component
        cam = GameObject.FindWithTag("MainCamera")?.GetComponent<Camera>();
        if (cam == null)
        {
            Debug.LogError("Main Camera not found or missing Camera component.");
            return;
        }

        // Ensure the platformPrefab is assigned in the inspector
        if (platformPrefab != null)
        {
            // Get the Renderer component from the prefab instance
            cubeRenderer = platformPrefab.GetComponent<Renderer>();
            if (cubeRenderer == null)
            {
                Debug.LogError("Platform prefab does not have a Renderer component.");
                return;
            }
        }
        else
        {
            Debug.LogError("Platform prefab is not assigned.");
            return;
        }

        // Initialize the camera and cube colors
        currentCameraColor = GetRandomColor();
        cam.backgroundColor = currentCameraColor;
        targetCameraColor = GetRandomColor();

        currentCubeColor = GetRandomColor();
        cubeRenderer.material.color = currentCubeColor;
        targetCubeColor = GetRandomColor();
    }

    void Update()
    {
        if (cam != null)
        {
            // Update the camera timer and smoothly transition the background color
            cameraTimer += Time.deltaTime;
            cam.backgroundColor = Color.Lerp(currentCameraColor, targetCameraColor, cameraTimer / cameraChangeInterval);

            // Check if the camera timer has exceeded the interval
            if (cameraTimer >= cameraChangeInterval)
            {
                cameraTimer = 0f;
                currentCameraColor = targetCameraColor;
                targetCameraColor = GetRandomColor();
            }
        }

        if (cubeRenderer != null)
        {
            // Update the cube timer and smoothly transition the cube color
            cubeTimer += Time.deltaTime;
            cubeRenderer.material.color = Color.Lerp(currentCubeColor, targetCubeColor, cubeTimer / cubeChangeInterval);

            // Check if the cube timer has exceeded the interval
            if (cubeTimer >= cubeChangeInterval)
            {
                cubeTimer = 0f;
                currentCubeColor = targetCubeColor;
                targetCubeColor = GetRandomColor();
            }
        }
    }

    // Method to generate a random color
    private Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}
