using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField nameField;
    public TextMeshProUGUI BestScoreText;

    private void Start()
    {
        if (DataPersistent.Instance != null)
        {
            BestScoreText.text = "Best Score : " +
                $"{DataPersistent.Instance.bestPlayerName} : {DataPersistent.Instance.BestScore}";
            nameField.text = DataPersistent.Instance.bestPlayerName;
        }
    }

    public void StartGame()
    {
        if (DataPersistent.Instance != null)
        {
            DataPersistent.Instance.playerName = nameField.text;
        }
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
