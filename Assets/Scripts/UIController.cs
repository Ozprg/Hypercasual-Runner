using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _nextLevelButton;

    public LevelController controller;

    private void OnEnable()
    {
        LevelController.Instance.OnPlayerCompletedLevel += OnPlayerCompletedLevel;
    }

    private void OnPlayerCompletedLevel()
    {
        _nextLevelButton.SetActive(true);
    }

    //Next level butonunun tıklandığı zaman çalışacak fonksiyon
    //Ataması buton componentindeki OnClick()'den yapılıyor
    public void NextLevelButtonClick()
    {
        LevelController.Instance.NextLevelButtonClicked(); //Next levele geç butonu tıklandığı eventini çalıştırır
        _nextLevelButton.SetActive(false); //butonu kapatır
    }
}
