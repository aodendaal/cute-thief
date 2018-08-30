using UnityEngine;

public class RotatingGuard : MonoBehaviour
{
    public GameObject targetMarker;


    private bool targetLocked = false;
    private float speed = 1f;

    private float pauseTime;
    private float pauseRate = 3f;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (!targetLocked)
        {
            var targetDirection = targetMarker.transform.position - transform.position;

            var step = speed * Time.deltaTime;

            var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0f);

            //Debug.Log(newDirection);

            var newRotation = Quaternion.LookRotation(newDirection);

            if (transform.rotation == newRotation)
            {
                targetLocked = true;
                pauseTime = Time.time + pauseRate;
            }
            else
            {
                transform.rotation = newRotation;
            }
        }
        else
        {
            if (pauseTime < Time.time)
            {
                var patrolMarker = targetMarker.GetComponent<PatrolMarker>();

                targetMarker = patrolMarker.nextMarker;
                targetLocked = false;
            }
        }
    }
}