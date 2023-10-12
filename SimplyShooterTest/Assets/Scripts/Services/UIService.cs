
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIService : MonoGenericSingelton<UIService> 
{
    [SerializeField]
    private TextMeshProUGUI coinAmtText;
    [SerializeField]
    private PlayerView player;
    [SerializeField]
    private Image hupeBarForeground;
    [SerializeField]
    private Image winLoseScreen;
    [SerializeField]
    private TextMeshProUGUI winLoseMessage;
    [SerializeField]
    private Button resartButton;
    private void Start()
    {
        EventService.Instance.CoinCollected += UpdateCoinCount;
        EventService.Instance.EnemyDied += IncreaseHypeBarFill;
        EventService.Instance.PlayerWon += () => { ShowWinLoseMessage("Player Won"); };
        EventService.Instance.PlayerLost += () => { ShowWinLoseMessage("Player Lost"); };
        resartButton.onClick.AddListener(RestartScene);
        hupeBarForeground.fillAmount = 0;
    }


    private void OnDestroy()
    {
        EventService.Instance.CoinCollected -= UpdateCoinCount;
        EventService.Instance.EnemyDied -= IncreaseHypeBarFill;
        EventService.Instance.PlayerWon -= () => { ShowWinLoseMessage("Player Won"); };
        EventService.Instance.PlayerLost -= () => { ShowWinLoseMessage("Player Lost"); };
    }

    private void Update()
    {
        if (player.PlayerController.GetInHypeMode())
            DecreaseHypeBarFill();
    }

    private void DecreaseHypeBarFill()
    {
        hupeBarForeground.fillAmount = player.PlayerController.GetHowMuchHypeIsLeft();
    }

    private void UpdateCoinCount(CoinPickupView controller)
    {
        coinAmtText.text = ": " + player.PlayerController.GetNumberOfCoinsCollected();
    }

    private void IncreaseHypeBarFill(EnemyView view)
    {
        if (player.PlayerController.GetInHypeMode())
            return;
        hupeBarForeground.fillAmount = player.PlayerController.GetHowMuchHypeIsCharged();
    }
    private void ShowWinLoseMessage(String messaeg)
    {
        winLoseScreen.gameObject.SetActive(true);
        winLoseMessage.text = messaeg;
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
