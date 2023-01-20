using UnityEngine;
using System.Collections.Generic;

public class GameLevel : MonoBehaviour
{
    public List<GameObject> allCollectibles { get; private set; }
    public List<GameObject> allObstacles { get; private set; }
    public GameObject player { get; private set; }

    private void Awake()
    {

        allCollectibles = new List<GameObject>();
        allObstacles = new List<GameObject>();

        //Bu gameobjenin altındakki tüm child objelere bak
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("Collectible")) //eğer child collectible ise collectible listesine ekle
            {
                allCollectibles.Add(child.gameObject);
            }
            else if (child.gameObject.CompareTag("Obstacle")) //eğer child obstacle ise obstacle listesine ekle
            {
                allObstacles.Add(child.gameObject);
            }
            else if (child.gameObject.CompareTag("Player")) //eğer child player ise playeri tanimla
            {
                player = child.gameObject;
            }
        }
    }
}
