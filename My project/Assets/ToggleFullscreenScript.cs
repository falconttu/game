using UnityEngine.Audio;
using UnityEngine;

public class ToggleFullscreenScript : MonoBehaviour
{
    // Creating Function to Toggle Fullscreen
    public void FullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    // Creating Function to Change Game Quality
    public void Quality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    // Creating Function to Chnage Game Volume

    public AudioMixer FireMixer;
    public void Volume(float volume)
    {
        FireMixer.SetFloat("Volume", volume);
    }
}
