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
        levelselector.SetActive(true);
    }
    private void Reset(){
        Debug.Log("Reset  the  games");
        PlayerPrefs.DeleteAll();
    }
    private void Exit(){
        Application.Quit();
    }
}
