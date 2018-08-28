using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    private float distance = 10f;

    private float xSpeed = 50f;
    private float ySpeed = 120f;

    private float x = 0f;
    private float y = 0f;

    public Transform target;

    private void Start()
    {
        x = transform.eulerAngles.y;
        y = transform.eulerAngles.x;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            if (Input.GetMouseButton(0))
            {
                x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            }

            var rotation = Quaternion.Euler(y, x, 0f);

            var position = rotation * new Vector3(0f, 0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}