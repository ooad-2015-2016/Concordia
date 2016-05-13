using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



public class MenuKlasa :MonoBehaviour
    {
         private ILevel level;

    internal ILevel Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }
}

