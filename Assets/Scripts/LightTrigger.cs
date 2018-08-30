using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var player = GameObject.FindObjectOfType<PhysicsPlayerController>();
            player.GameOver();

            var guards = GameObject.FindObjectsOfType<Guard>();

            foreach (var guard in guards)
            {
                guard.Disable();
            }
        }
    }
}
