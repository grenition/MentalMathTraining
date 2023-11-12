using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum QuestionsType
{
    additionAndSubtraction,
    multiplication,
    erectionAndExtractionOfSquaresEasy,
    erectionAndExtractionOfSquaresHard,
    decimalConvertion,
    decimalOperations,
    FSU,
    simpleEquation,
    squareEquation
}
public class LevelController : MonoBehaviour
{
    [Header("Default")]
    [SerializeField] protected QuestionsType questionsType;
    [SerializeField] protected AnswersController con;
                       
    [SerializeField] protected int questionsCount = 10;
    [SerializeField] protected Text questionsBar;
    [SerializeField] protected Button nextQuestionButton;
    [SerializeField] protected bool nextQuestionButtonActivated;
                       
    [SerializeField] protected GameObject endTitle;
    [SerializeField] protected Text endTitleText;

    [SerializeField] protected string statisticsName;

    protected int currentQuestion = 0;
    protected int score = 0;
    protected string lastQuestion;
    private void Start()
    {
        NextQuestion();
        nextQuestionButton.gameObject.SetActive(nextQuestionButtonActivated);
        nextQuestionButton.onClick.AddListener(NextQuestion);
    }
    public virtual void NextQuestion()
    {
        StopAllCoroutines();
        if (con == null)
            return;

        if (currentQuestion >= questionsCount && !endTitle.activeSelf)
        {
            endTitle.SetActive(true);
            endTitleText.text = $"Вы набрали {score} из {questionsCount} баллов!";


            WriteStatistics();

            return;
        }
        else if (currentQuestion >= questionsCount)
            return;

        currentQuestion++;
        questionsBar.text = $"{currentQuestion}/{questionsCount}";

        QuestionKit kit;
        for (; ; )
        {
            kit = GenerateKit(questionsType);
            if (kit.question != lastQuestion)
            {
                lastQuestion = kit.question;
                break;
            }
        }

        con.SetQuest(kit.question, kit.answers);

        if(nextQuestionButtonActivated)
            nextQuestionButton.gameObject.SetActive(false);
    }
    protected QuestionKit GenerateKit(QuestionsType _type)
    {
        switch (_type)
        {
            case QuestionsType.additionAndSubtraction:
                return QuestionsGenerator.GenerateKit_AdditionAndSubtraction();
            case QuestionsType.multiplication:
                return QuestionsGenerator.GenerateKit_Multiplication();
            case QuestionsType.erectionAndExtractionOfSquaresEasy:
                return QuestionsGenerator.Generate_ErectionAndExtractionOfSquaresEasy();
            case QuestionsType.erectionAndExtractionOfSquaresHard:
                return QuestionsGenerator.Generate_ErectionAndExtractionOfSquaresHard();
            case QuestionsType.decimalConvertion:
                return QuestionsGenerator.Generate_DecimalConvertion();
            case QuestionsType.decimalOperations:
                return QuestionsGenerator.Generate_DecimalOperations();
            case QuestionsType.FSU:
                return QuestionsGenerator.Generate_FSUQuestions();
            case QuestionsType.simpleEquation:
                return QuestionsGenerator.Generate_SimpleEquation();
            case QuestionsType.squareEquation:
                return QuestionsGenerator.Generate_SquareEquation();
        }

        return null;
    }

    private void CheckLastAnswerAngGoNextQuestion(bool isTrueAnswer)
    {
        if (isTrueAnswer)
            score++;

        if(nextQuestionButtonActivated)
            nextQuestionButton.gameObject.SetActive(true);
        StartCoroutine(WaitToNext(1f));
    }
    private IEnumerator WaitToNext(float time)
    {
        yield return new WaitForSeconds(time);
        NextQuestion();
    }

    protected void WriteStatistics()
    {
        if (!PlayerPrefs.HasKey("LevelsCount"))
            PlayerPrefs.SetInt("LevelsCount", 0);
        PlayerPrefs.SetInt("LevelsCount", PlayerPrefs.GetInt("LevelsCount") + 1);

        if (statisticsName != null)
        {
            if (!PlayerPrefs.HasKey($"LevelCount_{statisticsName}"))
                PlayerPrefs.SetInt($"LevelCount_{statisticsName}", 0);
            PlayerPrefs.SetInt($"LevelCount_{statisticsName}", PlayerPrefs.GetInt($"LevelCount_{statisticsName}") + 1);

            if (!PlayerPrefs.HasKey($"LevelADR{statisticsName}"))
                PlayerPrefs.SetFloat($"LevelADR{statisticsName}", 0f);
            //PlayerPrefs.SetFloat($"LevelADR{statisticsName}", 0f);
            float cur = System.Convert.ToSingle(score) / System.Convert.ToSingle(questionsCount);
            float half = PlayerPrefs.GetFloat($"LevelADR{statisticsName}") + cur;
            float res = half / System.Convert.ToSingle(PlayerPrefs.GetInt($"LevelCount_{statisticsName}"));
            PlayerPrefs.SetFloat($"LevelADR{statisticsName}", res);
        }
    }
    private void OnEnable()
    {
        con.onAnswered += CheckLastAnswerAngGoNextQuestion;
    }
    private void OnDisable()
    {
        
    }
}
