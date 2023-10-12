
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class LobbyView : MonoBehaviour
{
    [field: SerializeField]
    public Button PlayButton { get; private set; }
    [field: SerializeField]
    public Button QuitButton { get; private set; }

    [field: SerializeField]
    public Button StartButton { get; private set; }
    [field: SerializeField]
    public Button BackButton { get; private set; }
    [field: SerializeField]
    public GameObject ControlInfo { get; private set; }

    private void Start()
    {
        HideControlInfo();
        PlayButton.onClick.AddListener(ShowControlInfo);
        QuitButton.onClick.AddListener(QuitGame);
        StartButton.onClick.AddListener(StartGame);
        BackButton.onClick.AddListener(HideControlInfo);
    }


    private void ShowControlInfo()
    {
        ControlInfo.SetActive(true);
    }

    private void HideControlInfo()
    {
        ControlInfo.SetActive(false);

    }
    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
