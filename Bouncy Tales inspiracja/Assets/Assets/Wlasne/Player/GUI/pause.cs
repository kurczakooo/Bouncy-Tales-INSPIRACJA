using UnityEngine;

public class FreezeSceneGUIButton : MonoBehaviour
{

    private void Start()
    {
        SoundManager.SetMasterVolume(SoundManager.masterVolume);
    }
    // Funkcja do prze??czania stanu zamro?enia sceny
    public void ToggleFreezeScene()
    {
        // Sprawd?, czy skala czasu jest obecnie zamro?ona
        if (Time.timeScale == 0f)
        {
            // Je?li zamro?one, ustaw skal? czasu z powrotem na normaln? (1)
            Time.timeScale = 1f;
        }
        else
        {
            // Je?li nie zamro?one, zamro? scen? ustawiaj?c skal? czasu na 0
            Time.timeScale = 0f;
        }
    }
}
