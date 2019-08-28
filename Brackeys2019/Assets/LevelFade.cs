using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFade : MonoBehaviour
{
    public Animator anim;
    public string levelToLoad;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeToLevel(levelToLoad);
        }
    }

    // Fade to level specified by name
    public void FadeToLevel(string levelName)
    {
        levelToLoad = levelName;
        anim.SetTrigger("FadeOut");
    }

    // Fade to next level in build index
    public void FadeToNextLevel()
    {
        Scene nextScene = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1);
        FadeToLevel(nextScene.name);
    }

    // Load the new scene once the fade is complete
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
