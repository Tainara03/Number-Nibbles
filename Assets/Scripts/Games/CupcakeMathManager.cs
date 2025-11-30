using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class CupcakeMathManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text countDisplay;
    public TMP_Text equationText;
    [SerializeField] private TMP_Text resultMessageText;
    public TMP_Text scoreText;
    public GameObject successMessagePanel;
    public Button skipButton;
    public Button submitButton;

    [Header("Cupcakes")]
    public GameObject[] allCupcakes;

    [Header("Prato de Resultado")]
    public ResultPlateTrigger resultPlate;

    private int factorA;
    private int factorB;
    private int targetResult;
    private int score = 0;

    private enum Operation { Addition, Subtraction, Multiplication }
    private Operation currentOp;
    private bool scoredThisRound = false;

    void Start()
    {
        if(resultPlate != null && resultPlate.cupcakesOnPlate == null)
            resultPlate.cupcakesOnPlate = new System.Collections.Generic.List<GameObject>();

        GenerateNewProblem();

        skipButton.onClick.AddListener(NextGame);
        submitButton.onClick.AddListener(SubmitGame);

        UpdateScoreDisplay();
    }

    void Update()
    {
        UpdateCountDisplay();
    }

    private void GenerateNewProblem()
    {
        successMessagePanel.SetActive(false);
        scoredThisRound = false;

        foreach(GameObject cupcake in allCupcakes)
        {
            DraggableItem3D d = cupcake.GetComponent<DraggableItem3D>();
            if(d != null)
            {
                cupcake.transform.position = d.initialPosition;
                cupcake.transform.localScale = d.initialScale;
            }
        }

        if(resultPlate != null)
            resultPlate.cupcakesOnPlate.Clear();

        currentOp = (Operation)Random.Range(0, 3);
        bool valid = false;

        while(!valid)
        {
            factorA = Random.Range(1, 13);
            factorB = Random.Range(1, 13);

            switch(currentOp)
            {
                case Operation.Addition:
                    targetResult = factorA + factorB;
                    valid = targetResult <= 12;
                    break;
                case Operation.Subtraction:
                    if(factorA < factorB) { int tmp = factorA; factorA = factorB; factorB = tmp; }
                    targetResult = factorA - factorB;
                    valid = targetResult >= 0 && targetResult <= 12;
                    break;
                case Operation.Multiplication:
                    targetResult = factorA * factorB;
                    valid = targetResult <= 12;
                    break;
            }
        }

        switch(currentOp)
        {
            case Operation.Addition: equationText.text = $"{factorA} + {factorB} = ?"; break;
            case Operation.Subtraction: equationText.text = $"{factorA} - {factorB} = ?"; break;
            case Operation.Multiplication: equationText.text = $"{factorA} × {factorB} = ?"; break;
        }

        resultMessageText.text = "";
    }

    public void UpdateCountDisplay()
    {
        int total = 0;
        if(resultPlate != null && resultPlate.cupcakesOnPlate != null)
            total = resultPlate.cupcakesOnPlate.Count;

        countDisplay.text = $"Total: {total}";
    }

    private void UpdateScoreDisplay()
    {
        if(scoreText != null)
            scoreText.text = $"Score: {score}";
    }

    private void CheckResult()
    {
        if(resultPlate != null && resultPlate.cupcakesOnPlate != null)
        {
            if(resultPlate.cupcakesOnPlate.Count == targetResult && !scoredThisRound)
            {
                scoredThisRound = true;
                score++;
                UpdateScoreDisplay();

                resultMessageText.text = $"Congratulations! {targetResult}";
                successMessagePanel.SetActive(true);

                StartCoroutine(NextPhaseAfterDelay(2f));
            }
            else if(!scoredThisRound)
            {
                resultMessageText.text = $"Try Again!";
                successMessagePanel.SetActive(true);
            }
        }
    }

    private IEnumerator NextPhaseAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        successMessagePanel.SetActive(false);
        resultMessageText.text = "";
        GenerateNewProblem();
    }

    public void SubmitGame()
    {
        CheckResult();
    }

    public void NextGame()
    {
        GenerateNewProblem();
    }

    public void ResetGame()
    {
        score = 0;             
        UpdateScoreDisplay();
        GenerateNewProblem();
    }
}
