using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    [Header("HOLDERS")]
    [SerializeField] private Transform collectibleParticleHolder;
    [SerializeField] private Transform finishParticleHolder;
    [SerializeField] private Transform obstacleParticleHolder;

    [Header("COLLECTIBLE PARTICLES")]
    [SerializeField] private GameObject[] collectibleParticleArray;
    [SerializeField][Range(10, 20)] private int collectibleParticlePoolCount = 15;
    private List<GameObject> collectibleParticlePoolList;

    [Header("FINISH PARTICLES")]
    [SerializeField] private GameObject[] finishParticleArray;
    [SerializeField][Range(10, 20)] private int finishParticlePoolCount = 15;
    private List<GameObject> finishParticlePoolList;


    private void Start()
    {
        collectibleParticlePoolList = new List<GameObject>();
        finishParticlePoolList = new List<GameObject>();

        CreateCollectibleParticlePool();
        CreateFinishParticlePool();
    }

    private void OnEnable()
    {
        LevelController.Instance.OnNextLevelButtonClicked += ReleaseParticles;
    }

    private void OnDisable()
    {
        LevelController.Instance.OnNextLevelButtonClicked -= ReleaseParticles;
    }

    private void CreateCollectibleParticlePool()
    {
        for (int i = 0; i < collectibleParticlePoolCount; i++)
        {
            int randomIndex = Random.Range(0, collectibleParticleArray.Length);

            GameObject randomCollectibleParticle = collectibleParticleArray[randomIndex];
            GameObject collectibleParticle = Instantiate(randomCollectibleParticle, Vector3.zero, Quaternion.identity, collectibleParticleHolder);
            collectibleParticle.SetActive(false);
            collectibleParticlePoolList.Add(collectibleParticle);
        }
    }

    private void CreateFinishParticlePool()
    {
        for (int i = 0; i < finishParticlePoolCount; i++)
        {
            int randomIndex = Random.Range(0, finishParticleArray.Length);

            GameObject randomFinishParticle = finishParticleArray[randomIndex];
            GameObject finishParticle = Instantiate(randomFinishParticle, Vector3.zero, Quaternion.identity, finishParticleHolder);
            finishParticle.SetActive(false);
            finishParticlePoolList.Add(finishParticle);
        }
    }

    public GameObject GetCollectibleParticle()
    {
        GameObject collectibleParticle = collectibleParticlePoolList[0];
        collectibleParticlePoolList.Remove(collectibleParticle);
        collectibleParticle.SetActive(true);
        return collectibleParticle;
    }

    public GameObject GetFinishParticle()
    {
        GameObject finishParticle = finishParticlePoolList[0];
        finishParticlePoolList.Remove(finishParticle);
        finishParticle.SetActive(true);
        return finishParticle;
    }

    public void ReleaseParticles()
    {
        ReleaseAllCollectibleParticles();
        ReleaseAllFinishParticles();
    }

    private void ReleaseAllCollectibleParticles()
    {
        foreach (Transform child in collectibleParticleHolder)
        {
            GameObject particleGameObject = child.gameObject;
            particleGameObject.SetActive(false);
            collectibleParticlePoolList.Add(particleGameObject);
        }
    }

    private void ReleaseAllFinishParticles()
    {
        foreach (Transform child in finishParticleHolder)
        {
            GameObject particleGameObject = child.gameObject;
            particleGameObject.SetActive(false);
            finishParticlePoolList.Add(particleGameObject);
        }
    }
}
