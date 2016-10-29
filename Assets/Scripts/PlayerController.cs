using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public Animator eyeAnimator;
    public GameObject glassesSlot;
    List<string> keys = new List<string>(); //suas chaves
    public float grabDistance = 2.5f;
    public int checkPoint; //de 0 a 6

    // Use this for initialization
    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, grabDistance)) {
                print("Hit something at distance " + hit.distance + ". " + hit.collider.gameObject.tag);

                if (hit.collider.tag == "Glasses") {
                    if (glassesSlot.transform.childCount == 1) // já vestia óculos anteriormente
                    {
                        Transform t = hit.collider.transform;
                        GameObject curGlasses = glassesSlot.transform.GetChild(0).gameObject;

                        curGlasses.transform.position = t.position;
                        curGlasses.transform.rotation = t.rotation;
                        curGlasses.transform.SetParent(t.parent);
                    }
                    hit.collider.transform.SetParent(glassesSlot.transform);
                    hit.collider.transform.localPosition = Vector3.zero;
                    hit.collider.transform.localRotation = Quaternion.identity;
                    eyeAnimator.Play("eyeOclusion");
                } else if (hit.collider.tag == "Key") // pegou a chave e colocou no inventário
                  {
                    keys.Add(hit.collider.tag);
                } else if (hit.collider.tag == "Door") // tenta usar a chave na porta
                  {
                    if (keys.Contains(hit.collider.tag)) //verifica se tem a chave certa
                    {
                        //******
                        //CODIGO DE ABRIR PORTA
                        //******
                        keys.Remove(hit.collider.tag); //remove chave do inventario
                    } else {
                        //******
                        //MENSAGEM "Você não tem a chave para abrir essa porta"
                        //******
                    }
                }
            }
        } else if (Input.GetKeyDown(KeyCode.R)) {
            //SaveLoad.Load();
        }
    }
}
