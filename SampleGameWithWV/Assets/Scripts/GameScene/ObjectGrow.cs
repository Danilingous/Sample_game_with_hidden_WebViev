using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectGrow : MonoBehaviour
{
    private static float _pathLength = 5.3f;


    private void Start()
    {
        StartCoroutine(CoroutineGrowLerp());   
    }

    private IEnumerator CoroutineGrove()
    {
        float pathTime = _pathLength / ServiceLocator.Current.GetService<ForwardSpeedController>().CurrentSpeed;
        int iterationCount = (int)(pathTime / 0.05f);
        float growValue = 0.8f / iterationCount;

        for(int i=0;i<iterationCount;i++)
        {
            transform.localScale += new Vector3(growValue, growValue, growValue);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private IEnumerator CoroutineGrowLerp()
    {
        float currentSize = 0.2f;
        float pathTime=1;
        if (SceneManager.GetActiveScene().name != StringCommomValues.TutorialSceneName)
            pathTime = _pathLength / ServiceLocator.Current.GetService<ForwardSpeedController>().CurrentSpeed;
        else pathTime = _pathLength / 1.5f;
        float currentTime = 0f;
        while (currentSize<1)
        {
            
            transform.localScale = new Vector3(currentSize, currentSize, currentSize);
            currentSize = Mathf.Lerp(0.2f, 1f, currentTime / pathTime);
            currentTime += Time.deltaTime;
            yield return null;
        }
    }
}
