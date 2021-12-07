using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{
   private AudioSource _audioSource;
   private PlayMusic playUp;

   private void Awake()
   {
     if(playUp == null)
     {
        playUp = this;
     }else if(playUp != this)
     {
        Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
     }

      DontDestroyOnLoad(transform.gameObject);
      _audioSource = GetComponent<AudioSource>();
      PlaySong();
   }

   public void PlaySong()
   {
      if(_audioSource.isPlaying) return;
      _audioSource.Play();
   }

   public void StopSong()
   {
      _audioSource.Stop();
   }
}
