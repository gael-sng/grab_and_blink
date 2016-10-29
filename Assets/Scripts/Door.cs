using UnityEngine;
using System.Collections;
using System;

public class Door : MonoBehaviour {
    static private float closedRotation, thold = 5, nextPosition, velocity = 0;
    static public float openSpeed = 0.3f;

    public Boolean open = false;
    public string color;

    /*
     * 1 = AMARELO
     * 2 = VERMELHO
     * 3 = AZUL ESCURO
     * 4 = VERDE
     * 5 = ROXO
     * 6 = ROSA
     * 7 = LARANJA
     * 8 = AZUL CLARO
     */

    // Use this for initialization
    void Start () {
        closedRotation = transform.localEulerAngles.y;
        nextPosition = closedRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            transform.localEulerAngles = new Vector3(0, Mathf.SmoothDamp(transform.localEulerAngles.y, nextPosition, ref velocity, openSpeed), 0);
        }
    }
    public void Open() {
        if (transform.localEulerAngles.y < closedRotation - thold || transform.localEulerAngles.y > closedRotation + thold) { 
            nextPosition = closedRotation;
        }
        else
            nextPosition = (closedRotation + 120)%360;
        open = true;
    }
}
