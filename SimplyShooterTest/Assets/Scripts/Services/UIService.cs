
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIService : MonoGenericSingelton<UIService>
{
    public enum UpdateUi
    {
        Coin,
        HypeBar
    }
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

    private void OnDisable()
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
        StartCoroutine(WaitOneFrameUpdateUi(UpdateUi.Coin));
    }

    private void IncreaseHypeBarFill(EnemyView view)
    {
        if (player.PlayerController.GetInHypeMode())
            return;
        StartCoroutine(WaitOneFrameUpdateUi(UpdateUi.HypeBar));
    }
    private IEnumerator WaitOneFrameUpdateUi(UpdateUi ui)
    {
        yield return null;
        if (ui == UpdateUi.HypeBar)
            hupeBarForeground.fillAmount = player.PlayerController.GetHowMuchHypeIsCharged();
        else
            coinAmtText.text = ": " + player.PlayerController.GetNumberOfCoinsCollected();

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
