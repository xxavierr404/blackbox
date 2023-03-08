﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class RestartButton : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}