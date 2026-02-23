using UnityEngine;

public class Buttons : MonoBehaviour
{
    public string buttonID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnMouseDown()
    {

        FindFirstObjectByType<SequenceManager>().RegisterClick(buttonID);

        Debug.Log("Button Pressed!");


    }
}
