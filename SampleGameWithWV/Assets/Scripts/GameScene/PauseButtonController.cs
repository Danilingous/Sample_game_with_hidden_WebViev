using UnityEngine;

public class PauseButtonController : MonoBehaviour,IService
{
    public void ActivateButton() => gameObject.SetActive(true);
    public void DeactivateButton() => gameObject.SetActive(false);

}
