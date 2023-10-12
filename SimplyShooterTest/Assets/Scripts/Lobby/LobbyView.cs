
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class LobbyView : MonoBehaviour
{
    [field: SerializeField]
    public Button PlayButton { get;private set; }
    [field: SerializeField]
    public Button QuitButton { get; private set; }

    private void Start()
    {
        PlayButton.onClick.AddListener(PlayGame);
        QuitButton.onClick.AddListener(QuitGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
