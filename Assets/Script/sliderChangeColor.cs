using UnityEngine;
using UnityEngine.UI;

public class sliderChangeColor : MonoBehaviour
{
    // it's a code that changes object's color unsing slider
    public Slider slider;
    public GameObject rock;
    // 
    public Color sColor = new Color(); //start color choose by user
    public Color eColor = new Color(); //end color choose by user
    private SpriteRenderer rockRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rockRenderer = rock.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColor(float v)
    {
        Debug.Log("slider value:"+v);
        Color newColor = Color.Lerp(sColor, eColor, v);//change color during 2 color
        Debug.Log("new color:"+newColor);
        rockRenderer.color = newColor;//change object's color
    }
}
