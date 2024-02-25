using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerGameScene : MonoBehaviour,IService
{
    [SerializeField] private AudioSource _hockeyStickShotSound;
    [SerializeField] private AudioSource _addCoinSound;

    public void PlayHockeyStickShotSound() => _hockeyStickShotSound.Play();
    public void PlayAddCoinSound() => _addCoinSound.Play();
}
