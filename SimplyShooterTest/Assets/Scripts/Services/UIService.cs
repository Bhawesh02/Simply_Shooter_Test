
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoGenericSingelton<UIService> 
{
    [SerializeField]
    private TextMeshProUGUI coinAmtText;
    [SerializeField]
    private PlayerView player;
    [SerializeField]
    private Image hupeBarForeground;
    private void Start()
    {
        EventService.Instance.CoinCollected += UpdateCoinCount;
        EventService.Instance.EnemyDied += IncreaseHypeBarFill;
        hupeBarForeground.fillAmount = 0;
    }
    private void OnDestroy()
    {
        EventService.Instance.CoinCollected -= UpdateCoinCount;
        EventService.Instance.EnemyDied -= IncreaseHypeBarFill;
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

    private void UpdateCoinCount(CoinPickupController controller)
    {
        coinAmtText.text = ": " + player.PlayerController.GetNumberOfCoinsCollected();
    }

    private void IncreaseHypeBarFill(EnemyView view)
    {
        if (player.PlayerController.GetInHypeMode())
            return;
        hupeBarForeground.fillAmount = player.PlayerController.GetHowMuchHypeIsCharged();
    }

}
