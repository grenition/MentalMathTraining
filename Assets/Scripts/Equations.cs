using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationKit
{
    public string question;
    public string answer;

    public EquationKit(string _question, string _answer)
    {
        question = _question;
        answer = _answer;
    }
}
public class Equations : MonoBehaviour
{
    #region SimpleEquation
    public static EquationKit Generate_SimpleEquationType1()
    {
        //a + x = b or a - x = b
        int a = Random.Range(1, 100);
        int b = Random.Range(1, 100);
        int op = Random.Range(0, 2);

        if (op == 0)
        {
            int x = b - a;
            return new EquationKit($"{a} + x = {b}", x.ToString());
        }
        else
        {
            int x = a + b;
            return new EquationKit($"{a} - x = {b}", x.ToString());
        }
    }
    public static EquationKit Generate_SimpleEquationType2()
    {
        //a * (x + b) = c
        int b = Random.Range(1, 20);
        int x = Random.Range(1, 20);
        int a = Random.Range(1, 10);
        int c = a * (x + b);
        return new EquationKit($"{a} * (x + {b}) = {c}", x.ToString());
    }
    public static EquationKit Generate_SimpleEquationType3()
    {
        //ax + b = cx + d
        int a = Random.Range(1, 10);
        int c = Random.Range(1, 10);
        int x = Random.Range(1, 10);
        int b = ((a + c) * x) - Random.Range(1, 20);
        int d = ((a + c) * x) - b;
        return new EquationKit($"{a}x + {b} = {c}x + {d}", x.ToString());
    }
    public static EquationKit Generate_SimpleEquationType4()
    {
        //a * (bx + c) = d + e;
        //abx = d + e - ac;
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        int x = Random.Range(1, 10);
        int c = Random.Range(1, 10);
        int d = (a * b * x) + (a * c) - Random.Range(1, 20);
        int e = (a * b * x) + (a * c) - d;
        return new EquationKit($"{a} * ({b}x + {c}) = {d} + {e}", x.ToString());
    }
    public static EquationKit Generate_SimpleEquationType5()
    {
        //a + b + c + x = d + e
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        int c = Random.Range(1, 10);
        int x = Random.Range(1, 10);
        int d = a + b + c + x - Random.Range(1, 20);
        int e = a + b + c + x - d;
        return new EquationKit($"{a} + {b} + {c} + x = {d} + {e}", x.ToString());
    }
    public static EquationKit Generate_SimpleEquationType6()
    {
        //(a + b) * (c + x) = d
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        int c = Random.Range(1, 10);
        int x = Random.Range(1, 10);
        int d = (a + b) * (c + x);
        return new EquationKit($"({a} + {b}) * ({c} + x) = {d}", x.ToString());
    }
    public static EquationKit Generate_SimpleEquationType7()
    {
        //ax - b = c + d
        int a = Random.Range(1, 10);
        int x = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        int c = a * x - b - Random.Range(1, 20);
        int d = a * x - b - c;
        return new EquationKit($"{a}x - {b} = {c} + {d}", x.ToString());
    }
    public static EquationKit Generate_SimpleEquationType8()
    {
        //a * (b + cx) = a * d + a * e
        //b + cx = d + e
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        int c = Random.Range(1, 10);
        int x = Random.Range(1, 10);
        int d = b + (c * x) - Random.Range(1, 20);
        int e = b + (c * x) - d;
        return new EquationKit($"{a} * ({b} + {c}x) = {a * d} + {a * e}", x.ToString());
    }
    public static EquationKit Generate_SimpleEquationType9()
    {
        //ax - bx = c
        //x(a - b) = c
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        int x = Random.Range(1, 10);
        int c = (a * x) - (b * x);
        return new EquationKit($"{a}x - {b}x = {c}", x.ToString());
    }
    public static EquationKit Generate_SimpleEquationType10()
    {
        //a + bx + cx = a + e
        //x(b + c) = e
        int a = Random.Range(1, 10);
        int x = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        int c = Random.Range(1, 10);
        int e = x * (b + c);
        return new EquationKit($"{a} + {b}x + {c}x = {a} + {e}", x.ToString());
    }
    public static EquationKit GenerateRandom_SimpleEquation()
    {
        int rnd = Random.Range(0, 10);
        switch (rnd)
        {
            case 0:
                return Generate_SimpleEquationType1();
            case 1:
                return Generate_SimpleEquationType2();
            case 2:
                return Generate_SimpleEquationType3();
            case 3:
                return Generate_SimpleEquationType4();
            case 4:
                return Generate_SimpleEquationType5();
            case 5:
                return Generate_SimpleEquationType6();
            case 6:
                return Generate_SimpleEquationType7();
            case 7:
                return Generate_SimpleEquationType8();
            case 8:
                return Generate_SimpleEquationType9();
            case 9:
                return Generate_SimpleEquationType10();
            default:
                return Generate_SimpleEquationType1();

        }
    }
    #endregion
    #region SquareEquation

    #endregion
}
