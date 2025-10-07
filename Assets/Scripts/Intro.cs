using UnityEngine;
using UnityEngine.SceneManagement;

public class InputChecker : MonoBehaviour
{

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
