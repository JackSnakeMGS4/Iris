using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTransitions : MonoBehaviour
{
    public static ScreenTransitions current;

    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime;

    private void Awake()
    {
        current = this;
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLvl(SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCountInBuildSettings - 1 ? 
                                0 : SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLvl(int lvlIndex)
    {
        transition.SetTrigger("Start Screen Transition");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(lvlIndex);
    }
}
