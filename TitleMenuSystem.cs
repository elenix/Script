using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMenuSystem : MonoBehaviour {

    public GameObject MeteorMenu;
    public int rayCastLength = 100;
    public float menuTimer = 3.0f;
    //private AudioSource menuAudio;
    private RaycastHit shootHit;
    private float restartTimer;

    //private Text status_text;
    Image menuLoader;

    void Awake()
    {
        //menuAudio = GetComponent<AudioSource>();
        restartTimer = menuTimer;
        //status_text = StatusText.GetComponent<Text>();
        menuLoader = MeteorMenu.GetComponent<Transform>().FindChild("MeteorTitle_Loader").GetComponent<Image>();
        //playLoader = PlayButton.GetComponent<Transform>().FindChild("play_Loader").GetComponent<Image>();
        //restartLoader = RestartButton.GetComponent<Transform>().FindChild("restart_Loader").GetComponent<Image>();
        //homeLoader = HomeButton.GetComponent<Transform>().FindChild("home_Loader").GetComponent<Image>();
    }

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out shootHit, rayCastLength))
        {
            menuTimer -= Time.unscaledDeltaTime;
            menuLoader.fillAmount = menuTimer / restartTimer;
            if(menuTimer <= 0)
            {
                SceneManager.LoadScene(1);
            }
            
            //Debug.Log("there is object");
        //    if (shootHit.collider.gameObject.name.Equals("pause_b"))
        //    {
        //        //menuTimer -= Time.unscaledDeltaTime;
        //        //pauseLoader.fillAmount = menuTimer / restartTimer;

        //        //if (menuTimer <= 0)
        //        //{
        //        //    Time.timeScale = 0;
        //        //    status_text.text = "GAME PAUSED";
        //        //    PauseButton.SetActive(false);
        //        //    PauseMenu.SetActive(true);
        //        //    ShootSpawner.SetActive(false);
        //        //}
        //    }
        //    else if (shootHit.collider.gameObject.name.Equals("play_b"))
        //    {
        //        //menuTimer -= Time.unscaledDeltaTime;
        //        //playLoader.fillAmount = menuTimer / restartTimer;

        //        //if (menuTimer <= 0)
        //        //{
        //        //    Time.timeScale = 1;
        //        //    status_text.text = "";
        //        //    PauseMenu.SetActive(false);
        //        //    PauseButton.SetActive(true);
        //        //    ShootSpawner.SetActive(true);
        //        //}
        //    }
        //    else if (shootHit.collider.gameObject.name.Equals("home_b"))
        //    {
        //        //menuTimer -= Time.unscaledDeltaTime;
        //        //homeLoader.fillAmount = menuTimer / restartTimer;

        //        //if (menuTimer <= 0)
        //        //{
        //        //    SceneManager.LoadScene("meteor_scene");
        //        //}
        //    }
        //    else if (shootHit.collider.gameObject.name.Equals("restart_b"))
        //    {
        //        //menuTimer -= Time.unscaledDeltaTime;
        //        //restartLoader.fillAmount = menuTimer / restartTimer;

        //        //if (menuTimer <= 0)
        //        //{
        //        //    SceneManager.LoadScene("meteor_scene");
        //        //}
        //    }
        }
        else
        {
            menuTimer = restartTimer;
            menuLoader.fillAmount = menuTimer / restartTimer;
            //playLoader.fillAmount = menuTimer / restartTimer;
            //restartLoader.fillAmount = menuTimer / restartTimer;
            //homeLoader.fillAmount = menuTimer / restartTimer;
        }
    }
}
