using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] AudioSource audioSource;
        [SerializeField] AudioClip youWinClip;
        [SerializeField] AudioClip gameOverClip;
        [SerializeField] AudioClip objectClickedClip;
        [SerializeField] BoolVariable HasPlayerWin;

        public void PlayAudioClip(AudioClip audioClip)
        {
            Debug.Log("Playing sound");
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }

        public void PlayEndScreenClip(bool endScreen)
        {
            if (endScreen)
            {
                AudioClip audioClip = gameOverClip;
                if(HasPlayerWin.Value)
                {
                    audioClip = youWinClip;
                }
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
            }
        }
    }
}
//EOF.