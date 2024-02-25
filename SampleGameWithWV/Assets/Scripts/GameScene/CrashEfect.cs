using System.Collections;
using UnityEngine;

public class CrashEfect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _spriteSecondFrame;

    private void Start()
    {
        StartCoroutine(CoroutineLiveTime());
    }

    private IEnumerator CoroutineLiveTime()
    {
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.sprite = _spriteSecondFrame;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
