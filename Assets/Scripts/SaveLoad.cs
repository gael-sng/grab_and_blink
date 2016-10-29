using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{

    public static Game save;

    //it's static so we can call it from anywhere
    public static void Save()
    {
        save = Game.current;
    }

    public static void Load()
    {
        Game.current = save;
    }
}