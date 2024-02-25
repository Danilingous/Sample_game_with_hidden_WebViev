using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSwipeObject : MonoBehaviour
{
    [SerializeField] private float _speed;
    void Update()
    {
        transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);
        if (transform.position.x < 0)
        {
            ServiceLocator.Current.GetService<PlayerMove>().StartLeftMove();
            Destroy(gameObject);
        }
    }
}
