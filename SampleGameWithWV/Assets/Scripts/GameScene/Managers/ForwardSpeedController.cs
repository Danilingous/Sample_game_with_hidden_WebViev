using System.Collections;
using UnityEngine;

public class ForwardSpeedController : MonoBehaviour,IService
{
    public float CurrentSpeed { get; private set; } = 1.5f;
    [SerializeField] private float _stepTime = 5f;
    [SerializeField] private float _increaseCF=1.05f;

    private void Start()
    {
      StartCoroutine(  CoroutineIncreaseSpeed());
    }

    private IEnumerator CoroutineIncreaseSpeed()
    {
        while(true)
        {
            yield return new WaitForSeconds(_stepTime);
            CurrentSpeed *= _increaseCF;
        }
    }
}
