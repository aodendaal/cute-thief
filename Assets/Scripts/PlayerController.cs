using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject gameOver;

    private CharacterController controller;

    private float speed = 7f;

    private int score = 0;

    private bool isDisabled = false;

    // Use this for initialization
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (transform.position.y < -1f)
        {
            Disable();

            gameOver.SetActive(true);

            StartCoroutine(ReloadScene());
        }
    }

    private void FixedUpdate()
    {
        Vector3 move = Vector3.zero;

        if (!isDisabled)
        {
            var forward = Camera.main.transform.forward * Input.GetAxis("Vertical") * speed;
            var left = Camera.main.transform.right * Input.GetAxis("Horizontal") * speed;

            move = forward + left;
        }

        controller.SimpleMove(move);
    }

    public void AddScore(int points)
    {
        score += points;

        var scoreGameObject = GameObject.Find("Score");
        var scoreText = scoreGameObject.GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();
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