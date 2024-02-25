using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSwipesDetecter : MonoBehaviour,IService
{
   
    public bool IsAvaliableSwipeDetecte { get; private set; } = false;
    private bool _isDetectedTouch = false;
    private float _startXTouchPosition;
    private List<Touch> _avaliableTouches = new();
    [SerializeField] private float _botomYOffset = -100f;
    private float _deltaX = 0.3f;


    void Update()
    {
        DetecteSwipe();
    }

    private void DetecteSwipe()
    {
        if (IsAvaliableSwipeDetecte)
        {
            if (Input.touchCount > 0)
            {
                _avaliableTouches = new();
                for (int i = 0; i < Input.touches.Length; i++)
                {
                    if ((Camera.main.ScreenToWorldPoint(Input.touches[i].position).y > _botomYOffset)) _avaliableTouches.Add(Input.touches[i]);
                }

                if (_avaliableTouches.Count == 1)
                {
                    if (_avaliableTouches[0].phase == TouchPhase.Began)
                    {
                        _startXTouchPosition = (Camera.main.ScreenToWorldPoint(_avaliableTouches[0].position)).x;
                        _isDetectedTouch = true;
                    }

                    if (_avaliableTouches[0].phase == TouchPhase.Canceled || _avaliableTouches[0].phase == TouchPhase.Ended)
                    {
                        _isDetectedTouch = false;
                    }
                }
                else _isDetectedTouch = false;
            }
            else _isDetectedTouch = false;


            if (_isDetectedTouch)
            {
                if (Mathf.Abs((Camera.main.ScreenToWorldPoint(_avaliableTouches[0].position)).x - _startXTouchPosition) > _deltaX)
                {
                    if ((Camera.main.ScreenToWorldPoint(_avaliableTouches[0].position)).x - _startXTouchPosition > 0)
                        ServiceLocator.Current.GetService<PlayerMove>().StartRightMove();
                    else ServiceLocator.Current.GetService<PlayerMove>().StartLeftMove();

                    _isDetectedTouch = false;
                }
            }
        }
    }

    public void StartDetecteSwipes() => IsAvaliableSwipeDetecte = true;
    public void StopDetecteSwipes() => IsAvaliableSwipeDetecte = false;
}
