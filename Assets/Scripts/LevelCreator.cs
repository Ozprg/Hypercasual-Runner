using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public GameObject platform => _platform;
    public GameObject currentLevelGameObject => _currentLevelGameObject;


    [SerializeField] private GameObject _platform;
    [SerializeField] private GameObject[] _levels;
    private GameObject _currentLevelGameObject;
    private int _currentLevel;

    private void Awake()
    {
        //oyunun en başında level 1'den başlamak için 1'e atama yapıyoruz.
        //Daha sonradan kaldığımız levelden başlayacağımız sistemi entegre edeceğiz
        _currentLevel = 1;
    }

    private void OnEnable()
    {
        LevelController.Instance.OnPlayerCompletedLevel += OnPlayerCompletedLevel;
        LevelController.Instance.OnNextLevelButtonClicked += OnNextLevelButtonClicked;
    }

    private void OnDisable()
    {
        LevelController.Instance.OnPlayerCompletedLevel -= OnPlayerCompletedLevel;
        LevelController.Instance.OnNextLevelButtonClicked -= OnNextLevelButtonClicked;
    }

    private void Start()
    {
        CreateLevel(_currentLevel);
    }

    // Parametre olarak verilen leveli yaratan fonksiyon
    private void CreateLevel(int level)
    {
        if (level <= _levels.Length)
        {
            GameObject currentLevelPrefab = _levels[level - 1];
            _currentLevelGameObject = Instantiate(currentLevelPrefab, Vector3.zero, Quaternion.identity);
            GameLevel currentGameLevel = _currentLevelGameObject.GetComponent<GameLevel>();

            LevelController.Instance.LevelIsCreated(currentGameLevel);
        }
    }

    private void OnPlayerCompletedLevel()
    {
        _currentLevel++;

        if (_currentLevel > _levels.Length)
        {
            _currentLevel = 1;
        }
    }

    private void OnNextLevelButtonClicked()
    {
        Destroy(_currentLevelGameObject); //eskisini sil
        CreateLevel(_currentLevel); //yenisini yarat
    }
}