using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static float masterVolume;

    // Function to set the master volume level
    public static void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        // Optionally, you can apply the volume change to all audio sources in the scene
        ApplyVolumeToAllAudioSources();
    }

    // Function to apply the master volume to all audio sources in the scene
    private static void ApplyVolumeToAllAudioSources()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            source.volume = masterVolume;
        }
    }
}
