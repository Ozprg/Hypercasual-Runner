using UnityEngine;

[DefaultExecutionOrder(-50)]
public class LevelController : MonoBehaviour
{
    public LevelCreator levelCreator { get; private set; }
    public PoolingManager poolingManager;
    public AudioController audioController;
    private string _playerage;
    private static LevelController _instance;
    public static LevelController Instance { get { return _instance; } }
    // public LevelController Instance => _instance;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        levelCreator = GetComponent<LevelCreator>();
    }

    public delegate void OnPlayerCompletedLevelDelegate();
    public event OnPlayerCompletedLevelDelegate OnPlayerCompletedLevel;

    public delegate void OnNextLevelButtonClickedDelegate();
    public event OnNextLevelButtonClickedDelegate OnNextLevelButtonClicked;

    public delegate void OnLevelIsCreatedDelegate(GameLevel currentGameLevel);
    public event OnLevelIsCreatedDelegate OnLevelIsCreated;

    public delegate void OnFirstInputDetectedDelegate();
    public event OnFirstInputDetectedDelegate OnFirstInputDetected;


    //Player leveli başarılı bir şekilde tamamladığı yerde çağırılır
    public void PlayerCompletedLevel()
    {
        OnPlayerCompletedLevel.Invoke();
    }

    //Next level butonu tıklandığı yerde çağırılır
    public void NextLevelButtonClicked()
    {
        OnNextLevelButtonClicked.Invoke();
    }

    //Yeni level yaratıldığı zaman çağırılır
    public void LevelIsCreated(GameLevel currentGameLevel)
    {
        if (currentGameLevel)
        {
            OnLevelIsCreated.Invoke(currentGameLevel);
        }
    }

    //Kullanıcı oyun açıldığında ekranın herhangi bir yerine ilk defa bastığı zaman çağırılır
    public void FirstInputDetected()
    {
        OnFirstInputDetected.Invoke();
    }
}
