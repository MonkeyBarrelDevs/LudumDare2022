
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    private string backgroundTrack = "";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.SpatialBlend;
            s.source.maxDistance = s.MaxDistance;
            s.source.rolloffMode = AudioRolloffMode.Custom;
        }

        SceneManager.sceneLoaded += PlayByScene;
    }

    //Plays a sound effect using the name of the sound
    //Example: FindObjectOfType<Audio Manager>().Play(“SoundNmae”);
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            Play(MusicNames.Title.ToString());
    }

    public void PlayRandom(string[] randomSounds)
    {
        int soundIndex = UnityEngine.Random.Range(0, randomSounds.Length - 1);
        Sound s = Array.Find(sounds, sound => sound.name == randomSounds[soundIndex]);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        AudioClip clip = s.clip;
        s.source.PlayOneShot(clip);
    }

    public void RandomPlayOneShot(string[] randomSounds)
    {
        int soundIndex = UnityEngine.Random.Range(0, randomSounds.Length - 1);
        Sound s = Array.Find(sounds, sound => sound.name == randomSounds[soundIndex]);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        AudioClip clip = s.clip;
        s.source.PlayOneShot(clip);
    }

    //Stops playing a sound effect using the name of the sound
    //Example: FindObjectOfType<Audio Manager>().Stop(“SoundName”);
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    //Sets the volume of a sound effect
    //Example: FindObjectOfType<Audio Manager>().setVolume(“SoundName”, 1);
    public void setVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = volume;
    }

    //Checks to see if a sound with a specific name is currently playing
    //Example: FindObjectOfType<Audio Manager>().isPlaying(“SoundName”);
    public bool isPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return false;
        }
        return s.source.isPlaying;
    }

    #region BackgroundMusic
    private void PlayByScene(Scene scene, LoadSceneMode mode) 
    {
        PlayByScene(SceneController.GetActiveSceneName());
    }

    private void PlayByScene()
    {
        PlayByScene(SceneController.GetActiveSceneName());
    }

    public void PlayByScene(string toScene)
    {
        string nextTrack = GetNextBackgroundTrack(toScene);

        Debug.Log($"BG: {backgroundTrack}| next: {nextTrack}");

        if (backgroundTrack != nextTrack) 
        {
            if (isPlaying(backgroundTrack)) 
            {
                Stop(backgroundTrack);
            }
            Play(nextTrack); 

            backgroundTrack = nextTrack;
        }
    }

    private string GetNextBackgroundTrack(string sceneName) 
    {
        if (sceneName.Equals(SceneNames.Main.ToString()))
        {
            return MusicNames.Title.ToString();
        }
        else if (sceneName.Equals(SceneNames.Credits.ToString()))
        {
            return MusicNames.Credits.ToString();
        }
        else
        {
            return MusicNames.Song3.ToString();
        }
    }

    private enum SceneNames
    {
        Main,
        Credits
    }

    private enum MusicNames
    { 
        Title,
        Credits,
        Song3
    }
    #endregion
}
