using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  private static SoundManager instance;
  public static SoundManager Instance {get {return instance;}}

  public AudioSource  soundEffect;
  public AudioSource soundMusic;
  public SoundType[] Sounds;
  public bool IsMute=false;
  public float Volume=3f;
  private void Awake() {
      if(instance==null){
          instance=this;
          DontDestroyOnLoad(gameObject);
      }else{
          Destroy(gameObject);
      } 
    }
    private void Start() {
        SetVolume(3f);
        PlayMusic(global::Sounds.Music);
    }
    public void Mute(bool  status){
          IsMute=status;
    }
    public void SetVolume(float volume){
        Volume=volume;
        soundEffect.volume=Volume;
        soundMusic.volume=Volume;
    }
    public void PlayMusic(Sounds sound){
        if(IsMute)
           return;
        AudioClip clip=getSoundClip(sound);
        if(clip!=null){
            soundMusic.clip=clip;
            soundMusic.Play();
        }
    }
    public void Play(Sounds sound){
        AudioClip clip=getSoundClip(sound);
        if(clip!=null){
             soundEffect.PlayOneShot(clip);
        }else{
            Debug.Log("Clip  is  not found  sound type");
        }
    }
    private AudioClip getSoundClip(Sounds sound){
        SoundType item=Array.Find(Sounds,i=>i.soundTypes == sound);
        if(item!=null)
             return item.soundClip;
        return null;
    }
}
    
    [Serializable]
    public class SoundType{
        public Sounds soundTypes;
        public AudioClip soundClip;
    }
public enum Sounds{
    ButtonClick,
    Music,
    PlayerMove,
    PlayerDeath,
    EnemyStep,
    touch,
    PlayerJump,
    LevelComplete,
}