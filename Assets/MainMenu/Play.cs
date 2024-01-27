using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    [SerializeField]string LevelName;
    [SerializeField] string About;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void play()
    {
        SceneManager.LoadScene(LevelName);
    }

    public void about()
	{
        SceneManager.LoadScene(About);
	}

    public void End()
	{
        Application.Quit();
	}
}
