using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundFXManager : MonoBehaviour
{
   public static SoundFXManager instance;
   [SerializeField] private AudioSource soundFXObject;

   private void Awake()
   {
      if (instance==null)
      {
         instance = this;
      }
   }

   public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
   {
      AudioSource audioSource= Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
      
      audioSource.clip = audioClip;
      audioSource.volume = volume;
      audioSource.Play();
      float cliplength = audioSource.clip.length;
      Destroy(audioSource.gameObject, cliplength);
      
   }
}
