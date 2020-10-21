using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
//   public Button ButtonRestart;
    private void Awake() {
        // ButtonRestart.onClick.AddListener(ReloadLevel)
        ReloadLevel();
    }
    public  void PlayerDie(){
        gameObject.SetActive(true);
    }
    public void ReloadLevel(){
        SceneManager.LoadScene(0);
    }
}
