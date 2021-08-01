using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject playButton;
    public bool _paused=false;
    [SerializeField]
    Animator _anim;
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playButton.SetActive(true);
            pauseMenu.SetActive(true);
            
        }
    }
    public void restartGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void died()
    {
       
        _anim.SetTrigger("Hurt");
        _paused = true;
        playButton.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
