using UnityEngine;

public class FinishLine : MonoBehaviour, ICollidable
{
    [SerializeField][Range(1, 5)] private int _finishParticleCount = 5;

    public void OnPlayerCollision()
    {
        LevelController.Instance.audioController.PlayFinishSound();
        // Vibration.VibratePeek();

        for (int i = 0; i < _finishParticleCount; i++)
        {
            GameObject particle = LevelController.Instance.poolingManager.GetFinishParticle();

            particle.transform.position = transform.position;
            particle.transform.position += Vector3.up * i;
        }

        LevelController.Instance.PlayerCompletedLevel();
    }
}