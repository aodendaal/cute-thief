using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhysicsPlayerController : MonoBehaviour
{
    public GameObject gameOver;

    private float speed = 6.0f;
    private float jumpSpeed = 8.0f;
    private float gravity = 20.0f;

    private int score = 0;
    private bool isDisabled = false;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (transform.position.y < -1f)
        {
            GameOver();
        }
    }

    #region Movement

    // Update is called once per frame
    void FixedUpdate()
    {
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
                    moveDirection.y = jumpSpeed;

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

    public void AddScore(int points)
    {
        score += points;

        var scoreGameObject = GameObject.Find("Score");
        var scoreText = scoreGameObject.GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        Disable();

        gameOver.SetActive(true);

        StartCoroutine(ReloadScene());
    }

    public void Disable()
    {
        isDisabled = true;
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}