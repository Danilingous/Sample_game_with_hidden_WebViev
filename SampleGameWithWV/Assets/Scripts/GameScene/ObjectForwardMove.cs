using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectForwardMove : MonoBehaviour
{
    private float _speed=1.5f;
    private bool _isReadyToCreateNewLine = true;
     private float _yPositionToCreateNewLine = -1;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != StringCommomValues.TutorialSceneName)
            _speed = ServiceLocator.Current.GetService<ForwardSpeedController>().CurrentSpeed;
    }
    private void Update()
    {
        transform.position += new Vector3(0, -_speed*Time.deltaTime, 0);
        if(_isReadyToCreateNewLine)
        {
            if(transform.position.y<_yPositionToCreateNewLine)
            {
                _isReadyToCreateNewLine = false;
                if (SceneManager.GetActiveScene().name != StringCommomValues.TutorialSceneName)
                    ServiceLocator.Current.GetService<ObjectsCreator>().CreateLine();
            }
        }
    }
}
