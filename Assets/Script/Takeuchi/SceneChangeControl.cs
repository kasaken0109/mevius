using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeControl : MonoBehaviour
{
    static SceneChangeControl Instance;
    private void Awake()
    {
        Instance = this;
    }
    public static void SceneChange(int i)
    {
        switch (i)
        {
            case 0:
                SceneManager.LoadScene("TakeutiTest3");
                break;
            case 1:
                SceneManager.LoadScene("TakeutiTest4");
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            default:
                break;
        }
    }
}
