using UnityEngine;
using System.Collections;

public class LightEffect : MonoBehaviour {

    public bool lightOn, redColor, blueColor, blinkingLight;
    public float blinkingAverageInterval;

    private Light light;

    private float blinkingRandomInterval, blinkingCounter;
    // Use this for initialization
    void Start () {
        light = GetComponentInChildren<Light>();
	}

    void SwitchOn() {
        lightOn = !lightOn;
    }
	
	// Update is called once per frame
	void Update () {
        if (lightOn) {

            if (redColor) {
                light.color = Color.red;
            } else if (blueColor) {
                light.color = Color.blue;
            } else {
                light.color = Color.white;
            }

            if (blinkingLight) {

                if (blinkingCounter < blinkingAverageInterval + blinkingRandomInterval) {
                    blinkingCounter += Time.deltaTime;
                } else {
                    blinkingCounter = 0.0f;
                    light.enabled = !light.enabled;
                    blinkingRandomInterval = Random.Range(0, blinkingAverageInterval * 2.0f);
                }
            } else {
                light.enabled = true;
            }
        } else {
            light.enabled = false;
        }
	}
}
