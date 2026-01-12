using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{

    private void OnGUI()
    {
        int xCenter = (Screen.width / 2);
        int yCenter = (Screen.height / 2);
        int width = 400;
        int height = 120;

        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("button"));
        fontSize.fontSize = 32;

        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "scene1")
        {
            if(GUI.Button(new Rect(xCenter - width /2, yCenter - height / 2, width, height), "Load Second Scene", fontSize))
            {
                SceneManager.LoadScene("scene2");
            }
        }
        else
        {
            if(GUI.Button(new Rect(xCenter - width /2, yCenter - height / 2, width, height), "Return to First Scene", fontSize))
            {
                SceneManager.LoadScene("scene1");
            }
            
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
