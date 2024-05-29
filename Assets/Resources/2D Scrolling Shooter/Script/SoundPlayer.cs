using System;
using UnityEngine;
class SoundPlayer : MonoBehaviour
{
    // 소리 파일 (AudioClip).
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip explosionClip;

    // 유니티에서 소리 파일을 재생할 때 사용할 수 있는 컴포넌트.
    private AudioSource audioPlayer;

    private void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    // 오디오 재생 함수.
    public void PlayShootSound()
    {
        audioPlayer.PlayOneShot(shootClip);
        Debug.Log("OnShootEventRun");
    }

    public void PlayExplosionSound()
    {
        audioPlayer.PlayOneShot(explosionClip);
    }
}