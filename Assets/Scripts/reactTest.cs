using UnityEngine;

public class reactTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void MoveRight(float position)
    {
        this.gameObject.transform.position += new Vector3(position, 0, 0);
    }
    public void MoveLeft(float position)
    {
        this.gameObject.transform.position += new Vector3(-position, 0, 0);
    }
    public void MoveUp(int position)
    {
        this.gameObject.transform.position += new Vector3(0, position, 0);
    }
    public void MoveDown(int position)
    {
        this.gameObject.transform.position += new Vector3(0, -position, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp(1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft(1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight(1);
        }

        
    }
}
