
using TMPro;
using UnityEngine;

public class UIService : MonoGenericSingelton<UIService> 
{
    [SerializeField]
    private TextMeshProUGUI coinAmtText;
    [SerializeField]
    private PlayerView player;
    private void Start()
    {
        EventService.Instance.CoinCollected += UpdateCoinCount;
    }
    private void OnDestroy()
    {
        EventService.Instance.CoinCollected -= UpdateCoinCount;
    }
    private void UpdateCoinCount(CoinPickupController controller)
    {
        coinAmtText.text = ": " + player.PlayerController.GetNumberOfCoinsCollected();
    }
}
