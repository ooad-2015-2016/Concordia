﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class HighLevel : MonoBehaviour, ILevel
    {
        public void odaberiOpciju()
        {
            SceneManager.LoadScene("HighLevel");
        }
    }
}
