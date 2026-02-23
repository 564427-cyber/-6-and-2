using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SequenceManager : MonoBehaviour
{
    public List<string> correctOrder = new List<string>(); // Set in Inspector
    public string sceneToLoad;

    private int currentIndex = 0;

    public void RegisterClick(string buttonID)
    {
        if (correctOrder[currentIndex] == buttonID)
        {
            currentIndex++;

            if (currentIndex >= correctOrder.Count)
            {
                Debug.Log("Correct sequence!");
                SceneManager.LoadScene(sceneToLoad);
            }
        }
        else
        {
            Debug.Log("Wrong order! Resetting.");
            currentIndex = 0;
        }
    }
}
