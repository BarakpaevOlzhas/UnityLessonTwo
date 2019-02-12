using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform root;


    [SerializeField]
    private Text titleText, curScoreText, bestScoreText;


    [SerializeField]
    private Button nextBtn, quitBtn;


    void Start()
    {
        nextBtn.onClick.AddListener(Retry);
        quitBtn.onClick.AddListener(Quit);
        root.gameObject.SetActive(false);
    }

    public void Init(string title,float curScore, float bestScore)
    {
        root.gameObject.SetActive(true);

        titleText.text = title;

        curScoreText.text = "Your Score: " + curScore.ToString("0");

        bestScoreText.text = "Best Score: " + bestScore.ToString("0");
    }

    private void OnDestroy()
    {
        nextBtn.onClick.RemoveAllListeners();
        quitBtn.onClick.RemoveAllListeners();
    }

    private void Retry()
    {
        Debug.Log("Next pressed");
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
