using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<ICollisionHandler>()!=null)
        {
            collision.gameObject.GetComponent<ICollisionHandler>().HandlePlayerCollision();
        }
    }
}
