using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryBtn : MonoBehaviour
{
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => { Reload(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reload()
    {
        SceneManager.LoadScene(sceneName);
    }
}
