using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{ 
    public Button RestButton;
    public GameObject gameobject;
    private void Awake() {
        RestButton.onClick.AddListener(ReloadScene);
    }
    public void PlayerDie(){
         gameobject.SetActive(true);
    }
    private void ReloadScene(){
        SceneManager.LoadScene(1);
    }
}
