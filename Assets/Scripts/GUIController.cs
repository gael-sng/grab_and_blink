using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

    public float messageTime = 2.0f;

    private enum msg{ dontHaveKey, dontHaveAmulet, gotAmulet, gotKey, checkpoint, won, reset, unlockDoor, size};

    bool[] message = new bool[(int) msg.size];
    float[] counter = new float[(int) msg.size];

    private string paramMessage;
    // Use this for initialization
    void Start() {

        for (int i = 0; i < (int)msg.size; i++) {
            message[i] = false;
            counter[i] = 0.0f;
        }
    }

    // Update is called once per frame
    void Update () {

        for (int i=0; i<(int)msg.size; i++) {
            if (message[i]) {
                counter[i] += Time.deltaTime;
                if (counter[i] > messageTime) {
                    message[i] = false;
                }
            }
        }
	}

    public void DontHaveKeyMessage() {
        for (int i = 0; i < (int)msg.size; i++) {
            message[i] = false;
        }
        message[(int)msg.dontHaveKey] = true;
        counter[(int)msg.dontHaveKey] = 0.0f;
    }
    public void DontHaveAmuletMessage() {
        for (int i = 0; i < (int)msg.size; i++) {
            message[i] = false;
        }
        message[(int)msg.dontHaveAmulet] = true;
        counter[(int)msg.dontHaveAmulet] = 0.0f;
    }
    public void GotAmuletMessage(string amuletName) {
        for (int i = 0; i < (int)msg.size; i++) {
            message[i] = false;
        }
        message[(int)msg.gotAmulet] = true;
        counter[(int)msg.gotAmulet] = 0.0f;
        this.paramMessage = amuletName;
    }
    public void GotKeyMessage(string keyName) {
        for (int i = 0; i < (int)msg.size; i++) {
            message[i] = false;
        }
        message[(int)msg.gotKey] = true;
        counter[(int)msg.gotKey] = 0.0f;
        this.paramMessage = keyName;
    }
    public void CheckpointMessage() {
        for (int i = 0; i < (int)msg.size; i++) {
            message[i] = false;
        }
        message[(int)msg.checkpoint] = true;
        counter[(int)msg.checkpoint] = 0.0f;
    }
    public void wonMessage() {
        for (int i = 0; i < (int)msg.size; i++) {
            message[i] = false;
        }
        message[(int)msg.won] = true;
        counter[(int)msg.won] = 0.0f;
    }
    public void resetMessage() {
        for (int i = 0; i < (int)msg.size; i++) {
            message[i] = false;
        }
        message[(int)msg.reset] = true;
        counter[(int)msg.reset] = 0.0f;
    }
    public void unlockDoor() {
        for (int i = 0; i < (int)msg.size; i++) {
            message[i] = false;
        }
        message[(int)msg.reset] = true;
        counter[(int)msg.reset] = 0.0f;
    }

    void OnGUI() {
        string text;
        GUIStyle style;
        style = new GUIStyle();
        style.alignment = TextAnchor.MiddleCenter;
        style.fontSize = 20;

        if (message[(int)msg.dontHaveKey]) {
            text = "You don't have the right key to open this door!";
            GUI.Box(new Rect(0, Screen.height * 0.8f, Screen.width, 20), text, style);
        }
        if (message[(int)msg.dontHaveAmulet]) {
            text = "You don't have the right amulet to pass through this door!";
            GUI.Box(new Rect(0, Screen.height * 0.8f, Screen.width, 20), text, style);
        }
        if (message[(int)msg.gotAmulet]) {
            text = "You got the " + paramMessage + " amulet!";
            GUI.Box(new Rect(0, Screen.height * 0.8f, Screen.width, 20), text, style);
        }
        if (message[(int)msg.gotKey]) {
            text = "You got the " + paramMessage + " key!";
            GUI.Box(new Rect(0, Screen.height * 0.8f, Screen.width, 20), text, style);
        }
        if (message[(int)msg.checkpoint]) {
            text = "You passed through the Checkpoint! Press R go back here";
            GUI.Box(new Rect(0, Screen.height * 0.8f, Screen.width, 20), text, style);
        }
        if (message[(int)msg.won]) {
            text = "You won the game! :D";
            GUI.Box(new Rect(0, Screen.height * 0.8f, Screen.width, 20), text, style);
        }
        if (message[(int)msg.reset]) {
            text = "You reseted to the checkpoint!";
            GUI.Box(new Rect(0, Screen.height * 0.8f, Screen.width, 20), text, style);
        }
        if (message[(int)msg.unlockDoor]) {
            text = "You unlocked this door! You may pass through it without amulets for now on";
            GUI.Box(new Rect(0, Screen.height * 0.8f, Screen.width, 20), text, style);
        }
    }
}
