using TMPro;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    private float updateInterval = 0.5f;
    private float accum = 0f;
    private int frames = 0;
    private float timeLeft;
    private TextMeshProUGUI text;
private void Awake() {
    DontDestroyOnLoad(this.gameObject);
    text=GetComponent<TextMeshProUGUI>();
}
    private void Start()
    {
        timeLeft = updateInterval;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        frames++;

        if (timeLeft <= 0f)
        {
            float fps = accum / frames;
            string fpsText = string.Format("FPS: {0:F2}", fps);
            
            text.text=fpsText;
            // Optionally, display the FPS on the screen. 
            // You can create a UI Text element for this purpose.
            // textElement.text = fpsText;

            timeLeft = updateInterval;
            accum = 0f;
            frames = 0;
        }
    }
}
