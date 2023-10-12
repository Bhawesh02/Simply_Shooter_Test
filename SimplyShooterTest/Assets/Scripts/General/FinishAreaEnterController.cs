
using UnityEngine;

public class FinishAreaEnterController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.GetComponent<PlayerView>() != null)
            EventService.Instance.InvokePlayerEnteredFinishLine();
    }
}
