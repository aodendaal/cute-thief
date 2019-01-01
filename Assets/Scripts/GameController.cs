using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Singleton

    public static GameController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GameManager found!");
        }
        instance = this;
    }

    #endregion Singleton

    [SerializeField]
    private GameObject deadPanel;

    public void PlayerDies()
    {
        DisableGuards();
        DisablePlayer();

        deadPanel.SetActive(true);
        
        StartCoroutine(ReloadScene());
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1f);

        ScoreController.instance.ResetScore();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void DisablePlayer()
    {
        //isDisabled = true;
    }

    private void DisableGuards()
    {
        var guards = GameObject.FindObjectsOfType<Guard>();

        foreach (var guard in guards)
        {
            guard.Disable();
        }
    }
}