using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionKit
{
    public string question;
    public string[] answers;

    public QuestionKit(string _question, string[] _answers)
    {
        question = _question;
        answers = _answers;
    }
}
public class FractionQuestionKit
{
    public string firstNumerator;
    public string firstDenomerator;
    public string secondNumerator;
    public string secondDenomerator;
    public string fractionOperator;
    public string[] answers;

    public FractionQuestionKit(string _firstNumerator, string _firstDenomerator, string _secondNumerator, string _secondDenomirator, string _fractionOperator, string[] _answers)
    {
        firstNumerator = _firstNumerator;
        firstDenomerator = _firstDenomerator;
        secondNumerator = _secondNumerator;
        secondDenomerator = _secondDenomirator;
        fractionOperator = _fractionOperator;
        answers = _answers;
    }
}
public class QuestionsGenerator
{
    public static QuestionKit GenerateKit_AdditionAndSubtraction()
    {
        int op = Random.Range(0, 2);
        int firstValue = Random.Range(0, 101);
        int secondValue = Random.Range(0, 101);

        int result = 0;
        string opImage = "";

        switch (op)
        {
            case 0:
                result = firstValue + secondValue;
                opImage = "+";
                break;
            case 1:
                result = firstValue - secondValue;
                opImage = "-";
                break;
        }

        List<string> _answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                _answers.Add(result.ToString());
            else
            {
                int rnd = 0;

                for (; ; )
                {
                    rnd = Random.Range(result - 10, result + 10);
                    bool stop = true;
                    foreach (string ans in _answers)
                    {
                        if (rnd.ToString() == ans)
                            stop = false;
                    }
                    if (stop)
                        break;
                }

                _answers.Add(rnd.ToString());
            }
        }
        string question = $"{firstValue} {opImage} {secondValue}";
        return new QuestionKit(question, _answers.ToArray());
    }
    public static QuestionKit GenerateKit_Multiplication()
    {
        int firstValue = Random.Range(0, 11);
        int secondValue = Random.Range(0, 11);
        int result = firstValue * secondValue;

        List<string> _answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                _answers.Add(result.ToString());
            else
            {
                int rnd = 0;
                for (; ; )
                {
                    bool stop = true;
                    rnd = Random.Range(0, 101);
                    foreach(string ans in _answers)
                    {
                        if(ans == rnd.ToString())
                        {
                            stop = false;
                            break;
                        }
                    }
                    if (stop)
                        break;
                }
                _answers.Add(rnd.ToString());
            }
        }
        string question = $"{firstValue} * {secondValue}";
        return new QuestionKit(question, _answers.ToArray());
    }

    public static FractionQuestionKit Generate_AdditionAndSubtractionOfFractions()
    {
        int parametr = Random.Range(1, 4);
        int fd = Random.Range(1, 4) * parametr;
        int fn = Random.Range(1, 11) * fd;
        int sd = Random.Range(1, 4) * parametr;
        int sn = Random.Range(1, 11) * sd;

        int op = Random.Range(0, 2);
        int result = 0;

        string fo = "+";
        if (op == 1)
            fo = "-";

        if(op == 0)
        {
            result = (fn / fd) + (sn / sd);
        }
        else
        {
            result = (fn / fd) - (sn / sd);
        }

        List<string> answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                answers.Add(result.ToString());
            else
            {
                for (; ; )
                {
                    int rnd = Random.Range(result - 11, result + 11);
                    bool stop = true;
                    foreach(string ans in answers)
                    {
                        if (ans == rnd.ToString())
                            stop = false;
                    }
                    if (stop)
                    {
                        answers.Add(rnd.ToString());
                        break;
                    }
                }
            }
        }

        FractionQuestionKit kit = new FractionQuestionKit(fn.ToString(), fd.ToString(), sn.ToString(), sd.ToString(), fo, answers.ToArray());
        return kit;
    }
    public static FractionQuestionKit Generate_MultiplicationAndDivisionOfFractions()
    {
        int parametr = Random.Range(1, 4);
        int op = Random.Range(0, 2);

        int sd = Random.Range(1, 4) * parametr;
        int sn = Random.Range(1, 11) * sd;


        int fn = 0;
        int fd = Random.Range(1, 4) * parametr;
        if (op == 0)
            fn = Random.Range(1, 11) * fd;
        else
            fn = Random.Range(1, 11) * fd * (sn / sd);

        int result = 0;

        string fo = "*";
        if (op == 1)
            fo = ":";

        if (op == 0)
        {
            result = (fn / fd) * (sn / sd);
        }
        else
        {
            result = (fn / fd) / (sn / sd);
        }

        List<string> answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                answers.Add(result.ToString());
            else
            {
                for (; ; )
                {
                    int rnd = Random.Range(result - 11, result + 11);
                    bool stop = true;
                    foreach (string ans in answers)
                    {
                        if (ans == rnd.ToString())
                            stop = false;
                    }
                    if (stop)
                    {
                        answers.Add(rnd.ToString());
                        break;
                    }
                }
            }
        }

        FractionQuestionKit kit = new FractionQuestionKit(fn.ToString(), fd.ToString(), sn.ToString(), sd.ToString(), fo, answers.ToArray());
        return kit;
    }
    public static FractionQuestionKit Generate_ConvertingFractionsToDecimal ()
    {
        int parametr = Random.Range(1, 4);

        int[] denumerators = { 2, 4, 5, 8 };
        int fd = denumerators[Random.Range(0, denumerators.Length)];
        int fn = Random.Range(0, 17);

        float result = (float)fn / (float)fd;

        List<string> answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                answers.Add(result.ToString());
            else
            {
                for (; ; )
                {
                    float rnd = (int)Random.Range(fn - 5, fn + 5) / (float)denumerators[Random.Range(0, denumerators.Length)];
                    bool stop = true;
                    foreach (string ans in answers)
                    {
                        if (ans == rnd.ToString())
                            stop = false;
                    }
                    if (stop)
                    {
                        answers.Add(rnd.ToString());
                        break;
                    }
                }
            }
        }
        

        FractionQuestionKit kit = new FractionQuestionKit(fn.ToString(), fd.ToString(), "", "", "", answers.ToArray());
        return kit;
    }

    public static QuestionKit Generate_ErectionAndExtractionOfSquaresEasy()
    {
        int op = Random.Range(0, 2);
        int parametr = Random.Range(1, 21);
        string question = "";
        if (op == 0)
            question = $"{parametr}" + '\u00B2';
        else if (op == 1)
            question = '\u221A' + $"{parametr * parametr}";

        List<string> answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                if (op == 0)
                    answers.Add((parametr * parametr).ToString());
                else
                    answers.Add(parametr.ToString());
            }
            else
            {
                for (; ; )
                {
                    int rnd = Random.Range(parametr - 4, parametr + 4);
                    if (op == 0)
                        rnd *= rnd;

                        bool stop = true;
                    foreach (string ans in answers)
                    {
                        if (ans == rnd.ToString())
                            stop = false;
                    }
                    if (stop)
                    {
                        answers.Add(rnd.ToString());
                        break;
                    }
                }
            }
        }
        QuestionKit kit = new QuestionKit(question, answers.ToArray());
        return kit;
    }
    public static QuestionKit Generate_ErectionAndExtractionOfSquaresHard()
    {
        int op = Random.Range(0, 2);
        int parametr = Random.Range(19, 101);
        string question = "";
        if (op == 0)
            question = $"{parametr}" + '\u00B2';
        else if (op == 1)
            question = '\u221A' + $"{parametr * parametr}";

        List<string> answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                if (op == 0)
                    answers.Add((parametr * parametr).ToString());
                else
                    answers.Add(parametr.ToString());
            }
            else
            {
                for (; ; )
                {
                    int rnd = Random.Range(parametr - 10, parametr + 10);
                    if (op == 0)
                        rnd *= rnd;

                    bool stop = true;
                    foreach (string ans in answers)
                    {
                        if (ans == rnd.ToString())
                            stop = false;
                    }
                    if (stop)
                    {
                        answers.Add(rnd.ToString());
                        break;
                    }
                }
            }
        }
        QuestionKit kit = new QuestionKit(question, answers.ToArray());
        return kit;
    }

    public static QuestionKit Generate_DecimalConvertion()
    {
        int value = Random.Range(1, 100);
        int parametr = Random.Range(-5, 6);
        float a = (float)value / (float)(Mathf.Pow(10, parametr));
        string question = $"{a} * 10" + '\u1D61' + $" = {value}";

        List<string> _answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                _answers.Add(parametr.ToString());
            else
            {
                int rnd = 0;
                for (; ; )
                {
                    bool stop = true;
                    rnd = parametr + Random.Range(-4, 4);
                    //if (rnd != value)
                    //    break;

                    foreach(string ans in _answers)
                    {
                        if(ans == rnd.ToString())
                        {
                            stop = false;
                            break;
                        }
                    }
                    if (stop)
                        break;
                }
                _answers.Add(rnd.ToString());
            }
        }
        return new QuestionKit(question, _answers.ToArray());
    }
    public static QuestionKit Generate_DecimalOperations()
    {
        int twoValues = Random.Range(0, 2);
        int op = Random.Range(0, 3);
        int firstValue = 0;
        int secondValue = 0;
        int firstDecimal = 0;
        int secondDecimal = 0;
        float answer = 0;
        string question = string.Empty;

        if(twoValues == 1 && op != 2)
        {
            if(op == 0)
            {
                firstDecimal = 2;
                firstValue = Random.Range(1, 11);
                secondValue = Random.Range(1, 11);
                question = $"{firstValue}{ConvertToDecimal(firstDecimal)} * {secondValue}{ConvertToDecimal(firstDecimal)} = ?";
                answer = Mathf.Pow((float)firstValue, (float)firstDecimal) * Mathf.Pow((float)secondValue, (float)firstDecimal);
            }
            else if(op == 1)
            {
                firstDecimal = 2;
                secondValue = Random.Range(1, 11);
                firstValue = secondValue * Random.Range(1, 11);
                question = $"{firstValue}{ConvertToDecimal(firstDecimal)} : {secondValue}{ConvertToDecimal(firstDecimal)} = ?";
                answer = Mathf.Pow((float)firstValue, (float)firstDecimal) / Mathf.Pow((float)secondValue, (float)firstDecimal);
            }
        }
        else if(twoValues == 0 && op != 2)
        {
            if(op == 0)
            {
                firstValue = 2;
                firstDecimal = Random.Range(1, 4);
                for(; ; )
                {
                    secondDecimal = Random.Range(2, 4);
                    if (secondDecimal != firstDecimal)
                        break;
                }
                question = $"{firstValue}{ConvertToDecimal(firstDecimal)} * {firstValue}{ConvertToDecimal(secondDecimal)} = ?";
                answer = Mathf.Pow((float)firstValue, (float)firstDecimal) * Mathf.Pow((float)firstValue, (float)secondDecimal);
            }
            else if(op == 1)
            {
                firstValue = 2;
                firstDecimal = Random.Range(1, 100);
                secondDecimal = firstDecimal - Random.Range(1, 4);
                question = $"{firstValue}{ConvertToDecimal(firstDecimal)} : {firstValue}{ConvertToDecimal(secondDecimal)} = ?";
                answer = Mathf.Pow((float)firstValue,(float)(firstDecimal - secondDecimal));
            }
        }
        else
        {
            firstValue = 2;
            firstDecimal = 2;
            for (; ; )
            {
                secondDecimal = Random.Range(2, 4);
                if (secondDecimal != firstDecimal)
                    break;
            }
            question = $"({firstValue}{ConvertToDecimal(firstDecimal)}){ConvertToDecimal(secondDecimal)} = ?";
            answer = Mathf.Pow(Mathf.Pow((float)firstValue, (float)firstDecimal), (float)secondDecimal);
            answer = (float)System.Math.Round(answer, 3);
        }
        List<string> _answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                _answers.Add(answer.ToString());
            else
            {
                float rnd = 0;
                float ans = 0f;
                for (; ; )
                {
                    bool stop = true;
                    if (answer < 1f)
                    {
                        rnd = Random.Range(-0.2f, 0.2f);
                        rnd = (float)System.Math.Round(rnd, 3);
                        ans = answer + rnd;
                    }
                    else
                    {
                        rnd = Mathf.Round(Random.Range(1f, 10f));
                        ans = answer + rnd;
                    }
                    foreach(string _ans in _answers)
                    {
                        if(_ans == ans.ToString())
                        {
                            stop = false;
                            break;
                        }

                    }
                    if (stop)
                        break;
                }
                _answers.Add(ans.ToString());
            }
        }
        return new QuestionKit(question, _answers.ToArray());
    }
    private class FSU_kit
    {
        public string hiding;
        public string expansion;
        public FSU_kit(string _hiding, string _expansion)
        {
            hiding = _hiding;
            expansion = _expansion;
        }

        public static FSU_kit Get_FSU_kit(int index)
        {
            switch (index)
            {
                case 0:
                    return new FSU_kit("(a + b)²", "a² + 2ab + b²");
                case 1:
                    return new FSU_kit("(a - b)²", "a² - 2ab + b²");
                case 2:
                    return new FSU_kit("a² - b²", "(a + b)(a - b)");
                case 3:
                    return new FSU_kit("(a + b + c)²", "a² + b² + c² + 2ab + 2ac + 2bc");
                case 4:
                    return new FSU_kit("(a + b)³", "a³ + 3a²b + 3ab² + b³");
                case 5:
                    return new FSU_kit("(a - b)³", "a³ - 3a²b + 3ab² - b³");
                case 6:
                    return new FSU_kit("a³ + b³", "(a + b)(a² - ab + b²)");
                case 7:
                    return new FSU_kit("a³ - b³", "(a - b)(a² + ab + b²)");
                case 8:
                    return new FSU_kit("(a + b + с)³", "a³ + b³ + с³ + 3a²b + 3a²с + 3ab² +3aс² +3b²с + 3bc² +6abc");
                default:
                    return new FSU_kit("", "");
            }
        }
    }
    private static int lastFSUindex = 0;
    public static QuestionKit Generate_FSUQuestions()
    {
        FSU_kit kit = FSU_kit.Get_FSU_kit(lastFSUindex);
        string question = kit.expansion + " = ?";
        string answer = kit.hiding;

        List<string> _answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                _answers.Add(answer);
            else
            {
                FSU_kit _kit = new FSU_kit("","");
                int rnd = 0;
                for (; ; )
                {
                    bool stop = true;
                    rnd = Random.Range(0, 9);
                    _kit = FSU_kit.Get_FSU_kit(rnd);
                    foreach (string ans in _answers)
                    {
                        if (ans == _kit.hiding)
                        {
                            stop = false;
                            break;
                        }
                    }
                    if(stop)
                        break;
                }
                _answers.Add(_kit.hiding);
            }
        }
    
        lastFSUindex += 1;
            if (lastFSUindex == 8)
                lastFSUindex = 0;

        return new QuestionKit(question, _answers.ToArray());
    }
    public static QuestionKit Generate_SimpleEquation()
    {
        EquationKit kit = Equations.GenerateRandom_SimpleEquation();
        List<string> _answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                _answers.Add(kit.answer);
            else
            {
                int trueAnswer = System.Convert.ToInt32(kit.answer);
                int ans = 0;
                for(; ; )
                {
                    bool stop = true;
                    ans = trueAnswer + Random.Range(-4, 5);
                    foreach(string j in _answers)
                    {
                        if (j == ans.ToString())
                        {
                            stop = false;
                            break;
                        }
                    }
                    if(stop)
                        break;
                }
                _answers.Add(ans.ToString());
            }
        }
        return new QuestionKit(kit.question, _answers.ToArray());
    }
    public static QuestionKit Generate_SquareEquation()
    {
        //ax2 + bx + c = 0
        int x1 = Random.Range(-5, 6);
        int x2 = Random.Range(-5, 6);
        int a = Random.Range(1, 3);
        int b = a * (-x1 - x2);
        int c = a * x1 * x2;

        int d = (b * b) - 4 * a * c;

        string _a = a.ToString();
        if (a == 1)
            _a = "";
        string _b = "+ " + b.ToString();
        if (b == 1)
            _b = "+ ";
        else if(b < 0)
            _b = "- " + Mathf.Abs(b).ToString();
        string _c = "+ " + c.ToString();
        if (c == 1)
            _c = "+ ";
        else if (c < 0)
            _c = "- " + Mathf.Abs(c).ToString();

        string answer;
        string question = $"{_a}x{GetDecimal(2)} {_b}x {_c} = 0";

        if (d < 0)
        {
            answer = "Нет корней";
        }
        else if (d == 0)
        {
            answer = x1.ToString();
        }
        else
        {
            if (x1 != x2)
                answer = $"{x1}; {x2}";
            else
                answer = $"{x1}";
        }
        List<string> _answers = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
                _answers.Add(answer);
            else if (i == 1)
                _answers.Add((x1 + Random.Range(-2, 3)).ToString());
            else
            {
                int _x1;
                int _x2;

                for (; ; )
                {
                    bool stop = true;
                    _x1 = Random.Range(-5, 6);
                    _x2 = Random.Range(-5, 6);
                    if (_x1 == x1 || _x1 == x2 || _x2 == x1 || _x2 == x2)
                        continue;

                    foreach(string ans in _answers)
                    {
                        if($"{_x1}; {_x2}" == ans)
                        {
                            stop = false;
                            break;
                        }
                    }

                    if(stop)
                        break;
                }
                _answers.Add($"{_x1}; {_x2}");
            }
        }
        return new QuestionKit(question, _answers.ToArray());

    }
    public static string ConvertToDecimal(int value)
    {
        string txt = value.ToString();
        string _out = string.Empty;
        for (int i = 0; i < txt.Length; i++)
        {
            int.TryParse(txt[i].ToString(), out int _toFunction);
            _out += GetDecimal(_toFunction);
        }
        return _out;
    }
    public static char GetDecimal(int value)
    {
        switch (value)
        {
            case 0:
                return '\u2070';
            case 1:
                return '\u00B9';
            case 2:
                return '\u00B2';
            case 3:
                return '\u00B3';
            case 4:
                return '\u2074';
            case 5:
                return '\u2075';
            case 6:
                return '\u2076';
            case 7:
                return '\u2077';
            case 8:
                return '\u2078';
            case 9:
                return '\u2079';
        }
        return char.MinValue;
    }
}
