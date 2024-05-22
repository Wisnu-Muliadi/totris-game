using UnityEngine;
using Tomino.Model;

namespace Tomino.Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        public AudioClip pauseClip;
        public AudioClip resumeClip;
        public AudioClip newGameClip;
        public AudioClip pieceMoveClip;
        public AudioClip pieceRotateClip;
        public AudioClip pieceDropClip;
        public AudioSource audioSource, musicSource;
        
        public static AudioPlayer instance;
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                UpdateAudioClip();
                Destroy(gameObject);
            }
            musicSource.enabled = Settings.MusicEnabled;
        }

        void UpdateAudioClip()
        {
            instance.pauseClip = pauseClip;
            instance.resumeClip = resumeClip;
            instance.newGameClip = newGameClip;
            instance.pieceMoveClip = pieceMoveClip;
            instance.pieceRotateClip = pieceRotateClip;
            instance.pieceDropClip = pieceDropClip;
        }
        public void PlayPauseClip()
        {
            audioSource.PlayOneShot(pauseClip);
        }

        public void PlayResumeClip()
        {
            audioSource.PlayOneShot(resumeClip);
        }

        public void PlayNewGameClip()
        {
            audioSource.PlayOneShot(newGameClip);
        }

        public void PlayPieceMoveClip()
        {
            audioSource.PlayOneShot(pieceMoveClip);
        }

        public void PlayPieceRotateClip()
        {
            audioSource.PlayOneShot(pieceRotateClip);
        }

        public void PlayPieceDropClip()
        {
            audioSource.PlayOneShot(pieceDropClip);
        }

        public void PlayToggleOnClip()
        {
            audioSource.PlayOneShot(resumeClip);
        }

        public void PlayToggleOffClip()
        {
            audioSource.PlayOneShot(pauseClip);
        } 
        internal void Update()
        {
            audioSource.volume = PlayerPrefs.GetFloat("Volume");
            musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
    }
}
