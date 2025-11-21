using System.Collections.Generic;
using UnityEngine;

public enum AudioClips
{
    ChangeGravity,
    Onii_chan,
    Shot
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
    public Dictionary<AudioClips, AudioClip> clipList = new Dictionary<AudioClips, AudioClip>
    {

    };
    private void Awake()
    {
        Instance = this;
        clipList.Add(AudioClips.ChangeGravity, audioClips[0]);
        clipList.Add(AudioClips.Onii_chan, audioClips[1]);
    }

}
