using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public static Game current;
    public GameObject[] keys;
    public GameObject[] amulets;
    public GameObject[] doors;

    public Game()
    {
        keys = new GameObject[10];
        amulets = new GameObject[5];
        doors = new GameObject[21];
    }

}
