using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fish : MonoBehaviour
{
    //this scrpit was used to make prefab object move and turn 
    public float speed =1f; //speed
    public SpriteRenderer spriteRenderer; //get sprite
    private Vector2 moveX; //move in x deriction
    private bool right = true; //is if moving to right

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //get image of fish
        moveX = transform.position; //make sure the fish will start swimming at the location where it's spawned rather than at vector2.zero
        FlipSprite(); //a function to flip the image because when I draw them I draw them oppside way... 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); //get mouse position
        mousePos.z = 0;
        float d = Vector2.Distance(mousePos, transform.position); //distance between mouse position && object positiom

        if (d < 1f) // mouse distance near fish : 1f
        {
            //When the mouse approaches the fish, the fish will stop swimming and turn towards the direction of the mouse.
            Vector2 direction = mousePos - transform.position;
            transform.up = direction;
        }
        else //swim though the screen
        {
            if (right) //swim towards right
            {
                moveX.x += speed * Time.deltaTime; //x++
                
            }
            else
            {
                moveX.x -= speed * Time.deltaTime; //x-- (moving left)
            }
            transform.position = moveX; //acturaly moving code

            //check if it's aproch the screen edge
            if (transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x && right) //right edge
            {
                right = false; //change derection
                FlipSprite(); //flip image

            }
            else if(transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).x && !right) //left edge
            {
                right = true; //change derection
                FlipSprite(); //flip image
            }
            
        }
    }
    void FlipSprite() //when fish aproch the egde, flip their image
    {
        if (spriteRenderer != null) //check there's a sprite
        {
            spriteRenderer.flipX = !spriteRenderer.flipX; //flip image
        }
    }
}
