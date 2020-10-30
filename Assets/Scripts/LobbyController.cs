using UnityEngine;
using UnityEngine.UI;
public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject levelselector;
    private void Awake() {
        buttonPlay.onClick.AddListener(PlayGame);
    }
    private void PlayGame(){
        levelselector.SetActive(true);
    }
}
