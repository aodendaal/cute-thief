using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController), typeof(AudioSource))]
public class PhysicsPlayerController : MonoBehaviour
{

    private float speed = 6.0f;
    private float jumpSpeed = 8.0f;
    private float gravity = 20.0f;

    private bool isDisabled = false;

    private AudioSource source;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();
    }

    #region Movement

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1f)
        {
            GameController.instance.PlayerDies();
        }

        if (!isDisabled)
        {
            if (controller.isGrounded)
            {
                var forward = Camera.main.transform.forward * Input.GetAxis("Vertical");
                forward.y = 0;
                var right = Camera.main.transform.right * Input.GetAxis("Horizontal");
                right.y = 0;
                var direction = (forward + right).normalized;

                moveDirection = direction;
                moveDirection *= speed;
                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                    source.Play();
                }

                if (direction != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
                }

            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    #endregion

    public void Disable()
    {
        isDisabled = true;
    }

}