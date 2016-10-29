using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public Animator eyeAnimator;
    public GameObject amulet;
    List<string> keys = new List<string>(); //suas chaves
    public float grabDistance = 2.5f;

    static List<string> KEYS = new List<string>();
    static List<string> DOORS = new List<string>();
    static List<string> AMULETS = new List<string>();


    // Use this for initialization
    void Start () {
		//Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

        amulet = null;

        KEYS.Add("K1");
        KEYS.Add("K2");
        KEYS.Add("K3");
        KEYS.Add("K4");

        DOORS.Add("D1");
        DOORS.Add("D2");
        DOORS.Add("D3");
        DOORS.Add("D4");

        AMULETS.Add("A1");
        AMULETS.Add("A2");
        AMULETS.Add("A3");
        AMULETS.Add("A4");
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, grabDistance))
            {
                print("Hit something at distance " + hit.distance + ". " + hit.collider.gameObject.tag);

                if (AMULETS.Contains(hit.collider.gameObject.tag))
                {
                    if (amulet != null)
                    {
                        print("nao null");
                        GameObject aux = hit.collider.gameObject;
                        amulet.transform.position = hit.collider.transform.position;
                        Destroy(hit.collider.gameObject);
                        Instantiate(amulet);
                        amulet = aux;
                    }
                    else
                    {
                        print("null");
                        amulet = hit.collider.gameObject;
                        Destroy(hit.collider.gameObject);
                    }
                }
                else if (KEYS.Contains(hit.collider.gameObject.tag)) // pegou a chave e colocou no inventário
                {
                    keys.Add(hit.collider.gameObject.tag);
                    Destroy(hit.collider.gameObject);

                }
                else if (DOORS.Contains(hit.collider.gameObject.tag)) // tenta usar a chave na porta
                {
                    if (keys.Contains("K" + hit.collider.gameObject.tag.Remove(0, 1))) //verifica se tem a chave certa
                    {
                        hit.collider.gameObject.SendMessageUpwards("Open");
                        keys.Remove("K" + hit.collider.gameObject.tag.Remove(0, 1)); //remove chave do inventario
                    }
                    else
                    {
                        //mensagem
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            //Load
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, grabDistance))
            {
                //Teleport
                //blink
            }
        }
    }
}
