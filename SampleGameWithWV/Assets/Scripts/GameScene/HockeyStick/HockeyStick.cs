using System.Collections;
using UnityEngine;

public  class HockeyStick : MonoBehaviour
{
    [SerializeField] protected float _deltaX = 1;
    [SerializeField] protected float _deltaY = 3;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected float _lifeTime = 1;
    

    private void Start()
    {
        StartCoroutine(CoroutineBehavior());
    }


    protected virtual IEnumerator CoroutineBehavior()
    {
        int iterationCount =30;
        float deltaXForStep = _deltaX / iterationCount;
        float deltaYForStep = _deltaY / iterationCount;
        float deltaAlphaForStep = 1f / iterationCount;
        
        for(int i=0; i <iterationCount;i++)
        {
            transform.position += new Vector3(deltaXForStep, deltaYForStep, 0);
            _spriteRenderer.color = new Color(1, 1, 1, _spriteRenderer.color.a - deltaAlphaForStep);
            yield return new WaitForSeconds(_lifeTime / iterationCount);
        }
        
        Destroy(gameObject);
    }
    
    
}
