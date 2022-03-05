using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReplayButtonScript : MonoBehaviour
{
    public Button replayButton;

    void Start()
    {
        Button btn = replayButton.GetComponent<Button>();
        btn.onClick.AddListener(restart);
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
