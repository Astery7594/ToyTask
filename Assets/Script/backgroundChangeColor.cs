using UnityEngine;

public class backgroundChangeColor : MonoBehaviour
{
    // it change background color during time
    public float duringTime; //can set by user
    public float speed = 0.3f;//slowly change color
    public Color dColor = new Color(); // dark blue (adding in enging
    public Color bColor = new Color(); //bright blue (adding in enging

    private float t = 0;//time++

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(t < duringTime) //if curent time < seted time
        {
            t += Time.deltaTime * speed; //time++
            Camera.main.backgroundColor = Color.Lerp(bColor, dColor, t); //change color
        }
    }
}
