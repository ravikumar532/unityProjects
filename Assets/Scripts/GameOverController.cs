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
        SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
        gameObject.SetActive(true);

    }
    public void ReloadLevel(){
        SoundManager.Instance.PlayMusic(Sounds.Music);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Scene scene=SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
