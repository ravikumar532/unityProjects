using UnityEngine;
using UnityEngine.UI;
public class LobbyController : MonoBehaviour
{ 
    public Button buttonPlay;
    public Button ResetButton;
    public Button QuitButton;
    public GameObject levelselector;
    private void Awake() {
        buttonPlay.onClick.AddListener(PlayGame);
        ResetButton.onClick.AddListener(Reset);
        QuitButton.onClick.AddListener(Exit);
    }
    private void PlayGame(){
        SoundManager.Instance.Play(Sounds.ButtonClick);
        levelselector.SetActive(true);
    }
    private void Reset(){
        SoundManager.Instance.Play(Sounds.ButtonClick);
        PlayerPrefs.DeleteAll();
    }
    private void Exit(){
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }
}
