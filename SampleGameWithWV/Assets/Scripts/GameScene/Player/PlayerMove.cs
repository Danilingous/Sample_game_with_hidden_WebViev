using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerPositions
{
    left=-1,
    middle=0,
    right=1
}
public class PlayerMove : MonoBehaviour, IService
{
    [SerializeField] private float _speed=3f;
    [SerializeField] private float _stepMoveValue=1.4f;

    private PlayerPositions _lastReachedPosition = PlayerPositions.middle;
    private PlayerPositions _targetPosition = PlayerPositions.middle;
    private int _maxTernCount = 1;

    private void Update()
    {
        if (_targetPosition != _lastReachedPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3((int)_targetPosition * _stepMoveValue, transform.position.y,0), Time.deltaTime * _speed);
            if (transform.position.x == _stepMoveValue * (int)_targetPosition)
            {
                _lastReachedPosition = _targetPosition;
            }
        }
    }

    public void StartRightMove()
    {
        if ((int)_targetPosition < (int)_lastReachedPosition)
        {
            _lastReachedPosition = _targetPosition;
            _targetPosition = (PlayerPositions)((int)_targetPosition + 1);
            if (SceneManager.GetActiveScene().name != StringCommomValues.TutorialSceneName)
                ServiceLocator.Current.GetService<HockeySticksCreator>().CreateRightStick(transform.position);
        }
        else if ((int)_targetPosition == (int)_lastReachedPosition)
        {
            if ((int)_lastReachedPosition < _maxTernCount)
            {
                _targetPosition = (PlayerPositions)((int)_lastReachedPosition + 1);
              if(SceneManager.GetActiveScene().name!=StringCommomValues.TutorialSceneName)
                    ServiceLocator.Current.GetService<HockeySticksCreator>().CreateRightStick(transform.position);

            }
        }
        else
        {
            if((int)_targetPosition < _maxTernCount) _targetPosition = (PlayerPositions)((int)_targetPosition + 1);
            if (SceneManager.GetActiveScene().name != StringCommomValues.TutorialSceneName)
                ServiceLocator.Current.GetService<HockeySticksCreator>().CreateRightStick(transform.position);

        }
    }

    public void StartLeftMove()
    {
        if ((int)_targetPosition > (int)_lastReachedPosition)
        {
            _lastReachedPosition = _targetPosition;
            _targetPosition = (PlayerPositions)((int)_targetPosition -1);
            if (SceneManager.GetActiveScene().name != StringCommomValues.TutorialSceneName)
                ServiceLocator.Current.GetService<HockeySticksCreator>().CreateLeftStick(transform.position);

        }
        else if ((int)_targetPosition == (int)_lastReachedPosition)
        {
            if ((int)_lastReachedPosition > -_maxTernCount)
            {
                _targetPosition = (PlayerPositions)((int)_lastReachedPosition - 1);
                if (SceneManager.GetActiveScene().name != StringCommomValues.TutorialSceneName)
                    ServiceLocator.Current.GetService<HockeySticksCreator>().CreateLeftStick(transform.position);

            }
        }
        else
        {
            if ((int)_targetPosition >_maxTernCount) _targetPosition = (PlayerPositions)((int)_targetPosition - 1);
            if (SceneManager.GetActiveScene().name != StringCommomValues.TutorialSceneName)
                ServiceLocator.Current.GetService<HockeySticksCreator>().CreateLeftStick(transform.position);

        }
    }
}
