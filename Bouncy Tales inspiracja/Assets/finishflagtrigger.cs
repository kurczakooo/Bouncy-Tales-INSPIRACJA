using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishflagtrigger : MonoBehaviour
{
    public Canvas FinishLvlUI;
    public Camera MainCamera;
    public GameObject Player;
    public Timer timer;
    public float X;
    public float Y;
    public float newCameraSize;
    public AudioSource flagUnlock;
    public AudioSource winSound;
    public AudioSource level_sound;

    // Start is called before the first frame update
    void Start()
    {
        FinishLvlUI.enabled = false;
        SoundManager.SetMasterVolume(SoundManager.masterVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            level_sound.Stop();
            winSound.Play();

            timer.timeIsRunning = false;

            FinishLvlUI.enabled = true;

            Player.transform.position = new Vector3(X, Y, 0f);

            MainCamera.orthographicSize = newCameraSize;

            Player.SetActive(false);
        }
    }
}
