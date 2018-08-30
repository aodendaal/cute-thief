using UnityEngine;

public class Gold : MonoBehaviour
{
    public GameObject soundPrefab;

    private void Start()
    {
    }
    
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var player = GameObject.FindObjectOfType<PhysicsPlayerController>();
            player.AddScore(100);

            var sound = Instantiate(soundPrefab, transform.position, Quaternion.identity);
            Destroy(sound, 1f);

            Destroy(gameObject);
        }
    }
}