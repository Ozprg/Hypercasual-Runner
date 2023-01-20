using UnityEngine;

public class CollectibleController : MonoBehaviour, ICollidable
{
    [SerializeField] private GameObject collectParticle;

    public void OnPlayerCollision()
    {
        LevelController.Instance.audioController.PlayCollectibleSound();
        // Vibration.Vibrate();

        GameObject particle = LevelController.Instance.poolingManager.GetCollectibleParticle();
        particle.transform.position = transform.position;

        gameObject.SetActive(false);
    }
}
