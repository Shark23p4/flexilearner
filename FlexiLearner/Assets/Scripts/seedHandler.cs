using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class seedHandler : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void GETCONFIGINDEX();


    public static bool progressOn;
    public static bool heartsOn;
    public static bool pointsOn;
    public static bool meaningOn;
    public static bool streakOn;
    public InputField input;
    public string sequence;
    public int configIndex = -1;
    public GameObject failText;

    public static string email;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        progressOn = false; heartsOn = false; pointsOn = false; meaningOn = false; streakOn = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void processInput(int index)
    {
        switch (index)
        {
            case 0:
                sequence = "ABCD"; break;
            case 1:
                sequence = "BCDA"; break;
            case 2:
                sequence = "DABC"; break;
            case 3:
                sequence = "CDAB"; break;
        }
    }

    public void currentConfig(int index) {
        if (index >= sequence.Length)
            return;
        char c = sequence.ToCharArray()[index];
        switch (c)
        {
            case 'A': // Control
                progressOn = false; heartsOn = false; pointsOn = false; meaningOn = false; streakOn = false; break;
            case 'B': // Points
                progressOn = false; heartsOn = false; pointsOn = true; meaningOn = false; streakOn = false; break;
            case 'C': // Consequence
                progressOn = false; heartsOn = true; pointsOn = false; meaningOn = false; streakOn = false; break;
            case 'D': // Both
                progressOn = false; heartsOn = true; pointsOn = true; meaningOn = false; streakOn = false; break;
        }
    }

    public void nextConfig()
    {
        configIndex += 1;
        currentConfig(configIndex);
    }

    public void proceed()
    {
        if (true)
        {
            email = input.text.Trim();
            GETCONFIGINDEX(); // Call JavaScript function to retrieve index
            StartCoroutine(ProceedCoroutine()); // Start coroutine to wait for JavaScript call to complete
        }
        else
        {
            StartCoroutine(displayError());
        }

    }

    private IEnumerator ProceedCoroutine()
    {
        yield return new WaitUntil(() => configIndex != -1); // Wait until index is updated
        nextConfig(); // Proceed to next configuration
        SceneManager.LoadScene("Questions"); // Load the Questions scene
    }

    IEnumerator displayError()
    {

        failText.SetActive(true);
        yield return new WaitForSeconds(4);
        failText.SetActive(false);
    }
}
