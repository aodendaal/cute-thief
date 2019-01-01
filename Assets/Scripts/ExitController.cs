using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitController : MonoBehaviour
{
    public GameObject levelCompletePanel;
    public int totalTreasures;
    public string nextLevel;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Exit trigger fired");

        if (other.tag == "Player")
        {
            GameController.instance.DisablePlayer();

            levelCompletePanel.SetActive(true);

            var treasureCount = GameObject.Find("Treasure Count").GetComponent<Text>();
            treasureCount.text = string.Format("Treasures: {0}/{1}", totalTreasures - GameObject.FindObjectsOfType<Gold>().Length, totalTreasures);

            StartCoroutine(LoadScene());
        }
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1f);

        ScoreController.instance.SetRestartScore();

        SceneManager.LoadScene(nextLevel);
    }
}