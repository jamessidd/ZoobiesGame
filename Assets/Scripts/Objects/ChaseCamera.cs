using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceBehind = 5f; // distance behind the player
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float lookSpeed = 5f;
    [SerializeField] private float fovSpeed = 5f;
    [SerializeField] private float highVelocity = 30f;
    [SerializeField] private float lowFov = 60f;
    [SerializeField] private float highFov = 100f;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if (player == null || target == null)
            return;

        // Calculate desired position: player's position minus distance behind in the player's forward direction
        Vector3 desiredPosition = player.position - player.forward * distanceBehind;

        // Smoothly move camera to desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Calculate rotation to look at the target with same pitch and yaw
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, target.up);

        // Smoothly rotate camera to desired rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, lookSpeed * Time.deltaTime);

        // Adjust FOV based on velocity
        float playerVelocity = player.GetComponent<Rigidbody>().velocity.magnitude;
        float desiredFov = (playerVelocity > highVelocity) ? highFov : lowFov;
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, desiredFov, fovSpeed * Time.deltaTime);
    }
}



