using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollidable collidable = other.gameObject.GetComponent<ICollidable>();

        if (collidable != null)
        {
            collidable.OnPlayerCollision();
        }
    }
}