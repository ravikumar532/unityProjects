using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameoverController : MonoBehaviour
{
   public Button ButtonRestart;
   
    private void Awake() {
     ButtonRestart.onClick.AddListener(ReloadLevel);
    }
    public  void PlayerDie(){

        gameObject.SetActive(true);
    }
    public void ReloadLevel(){
        Scene scene=SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
