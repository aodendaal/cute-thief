using UnityEngine;
using Random = UnityEngine.Random;

public class Gold : MonoBehaviour
{
    public GameObject soundPrefab;

    private float rotateSpeed = 100f;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
    }
    
    private void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ScoreController.instance.AddScore(100);

            var sound = Instantiate(soundPrefab, transform.position, Quaternion.identity);
            Destroy(sound, 1f);

            Destroy(gameObject);
        }
    }
}