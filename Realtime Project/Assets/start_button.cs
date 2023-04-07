using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_button : MonoBehaviour
{
    public void Clicked()
    {
        SceneManager.LoadScene("RoomEnvironmentScene");
    }
}
