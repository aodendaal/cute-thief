using UnityEngine;

public class Guard : MonoBehaviour
{
    public GameObject targetMarker;

    private CharacterController controller;

    private float speed = 2f;

    private bool isDisabled = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (!isDisabled)
        {
            var move = Vector3.zero;

            if (targetMarker != null)
            {
                var heading = targetMarker.transform.position - transform.position;
                heading.Normalize();

                var rotation = new Vector3(heading.x, 0f, heading.z);

                transform.rotation = Quaternion.LookRotation(rotation);

                move += heading * speed;
            }

            controller.SimpleMove(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Patrol Marker" && other.gameObject == targetMarker)
        {
            var marker = other.GetComponent<PatrolMarker>();

            targetMarker = marker.nextMarker;
        }
    }

    public void Disable()
    {
        isDisabled = true;
    }
}