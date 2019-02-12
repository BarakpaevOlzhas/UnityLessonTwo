using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    // Start is called before the first frame update    

    [SerializeField]
    private Transform root;


    [SerializeField]
    private Text curScoreText, bestScoreText;


    [SerializeField]
    private Button retryBtn, quitBtn;


    void Start()
    {
        retryBtn.onClick.AddListener(Retry);
        quitBtn.onClick.AddListener(Quit);
        root.gameObject.SetActive(false);
    }

    public void Init(float curScore, float bestScore)
    {
        root.gameObject.SetActive(true);

        curScoreText.text = "Your score " + curScore.ToString("0");

        bestScoreText.text = "Best score " + bestScore.ToString("0");
    }

    private void OnDestroy()
    {
        retryBtn.onClick.RemoveAllListeners();
        quitBtn.onClick.RemoveAllListeners();
    }

    private void Retry()
    {
        Debug.Log("Retru pressed");
    }

    private void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
