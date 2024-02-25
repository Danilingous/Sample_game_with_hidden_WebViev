using System.Collections;
using UnityEngine;

public class CanvasAnimationMaster : MonoBehaviour, IService
{
    public void ReplaceCanvases(GameObject imageOldCanvas, GameObject imageNewCanvas)
    {
        StartCoroutine(CoroutineReplaceCanvases(imageOldCanvas, imageNewCanvas));
    }

    private IEnumerator CoroutineReplaceCanvases(GameObject imageOldCanvas, GameObject imageNewCanvas)
    {
        ServiceLocator.Current.GetService<MenuSceneMaster>().ForbidClickUIButtons();
        float currentScaleValue = 1;

        for (int i = 0; i < 10; i++)
        {
            currentScaleValue -= 0.125f;
            imageOldCanvas.GetComponent<RectTransform>().localScale = new Vector3(1, currentScaleValue, currentScaleValue);
            yield return new WaitForSeconds(0.02f);
        }
        imageOldCanvas.GetComponent<RectTransform>().localScale = Vector3.zero;
        currentScaleValue = 0;
        for (int i = 0; i < 8; i++)
        {
            currentScaleValue += 0.125f;
            imageNewCanvas.GetComponent<RectTransform>().localScale = new Vector3(1, currentScaleValue, currentScaleValue);
            yield return new WaitForSeconds(0.02f);
        }
        imageNewCanvas.GetComponent<RectTransform>().localScale = Vector3.one;
        ServiceLocator.Current.GetService<MenuSceneMaster>().LetClickUIButtons();
    }
    public void RegisterHandler()
    {
        Debug.Log(this.GetType().Name + " registred");
    }

}
