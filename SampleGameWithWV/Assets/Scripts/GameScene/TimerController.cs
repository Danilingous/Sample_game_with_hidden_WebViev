using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour, IService
{
    [SerializeField] private Text _textTimerValue;
    [SerializeField] private Image _forwardImage;

    public void StartWorkCountDown(float timeValue, Action methodAfterCountDown)
    {
        StartCoroutine(CoroutineCountDownText(timeValue, methodAfterCountDown));
    }


    private IEnumerator CoroutineCountDownText(float timeValue, Action methodAfterCountDown)
    {
        float currentTimeValue = timeValue;
        float currentFieldValue = 1;
       
        while(currentTimeValue>0)
        {
            _forwardImage.fillAmount = currentFieldValue;
            _textTimerValue.text = ((int)currentTimeValue).ToString();
            yield return new WaitForSecondsRealtime(0.05f);
            currentTimeValue -= 0.05f;
            currentFieldValue -= 0.05f / timeValue;
        }
        _textTimerValue.text = "0";
        _forwardImage.fillAmount = 0;

        methodAfterCountDown?. Invoke();
    }

   public void StopCountDown()
    {
        StopAllCoroutines();
    }
}
