namespace MyClasses
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    internal class ExpressionEvaluator<T> where T: ab, new()
    {
        private Dictionary<string, delExpressionVariable<T>> a;
        private T b;
        private static Dictionary<char, eTokenCharType<T>> c;

        static ExpressionEvaluator()
        {
            ExpressionEvaluator<T>.c = new Dictionary<char, eTokenCharType<T>>();
            ExpressionEvaluator<T>.a();
        }

        public ExpressionEvaluator()
        {
            this.a = new Dictionary<string, delExpressionVariable<T>>();
        }

        private static void a()
        {
            ExpressionEvaluator<T>.c['+'] = eTokenCharType<T>.d;
            ExpressionEvaluator<T>.c['-'] = eTokenCharType<T>.d;
            ExpressionEvaluator<T>.c['*'] = eTokenCharType<T>.d;
            ExpressionEvaluator<T>.c['/'] = eTokenCharType<T>.d;
            ExpressionEvaluator<T>.c['%'] = eTokenCharType<T>.d;
            ExpressionEvaluator<T>.c['#'] = eTokenCharType<T>.d;
            ExpressionEvaluator<T>.c['<'] = eTokenCharType<T>.d;
            ExpressionEvaluator<T>.c['>'] = eTokenCharType<T>.d;
            ExpressionEvaluator<T>.c['='] = eTokenCharType<T>.d;
            ExpressionEvaluator<T>.c['!'] = eTokenCharType<T>.d;
            ExpressionEvaluator<T>.c['&'] = eTokenCharType<T>.d;
            ExpressionEvaluator<T>.c['|'] = eTokenCharType<T>.d;
            ExpressionEvaluator<T>.c['('] = eTokenCharType<T>.e;
            ExpressionEvaluator<T>.c[')'] = eTokenCharType<T>.f;
            ExpressionEvaluator<T>.c['0'] = eTokenCharType<T>.b;
            ExpressionEvaluator<T>.c['1'] = eTokenCharType<T>.b;
            ExpressionEvaluator<T>.c['2'] = eTokenCharType<T>.b;
            ExpressionEvaluator<T>.c['3'] = eTokenCharType<T>.b;
            ExpressionEvaluator<T>.c['4'] = eTokenCharType<T>.b;
            ExpressionEvaluator<T>.c['5'] = eTokenCharType<T>.b;
            ExpressionEvaluator<T>.c['6'] = eTokenCharType<T>.b;
            ExpressionEvaluator<T>.c['7'] = eTokenCharType<T>.b;
            ExpressionEvaluator<T>.c['8'] = eTokenCharType<T>.b;
            ExpressionEvaluator<T>.c['9'] = eTokenCharType<T>.b;
            ExpressionEvaluator<T>.c['.'] = eTokenCharType<T>.b;
        }

        private static object a(cv A_0)
        {
            return 0.0;
        }

        private sExpressionToken<T> a(string A_0)
        {
            if (A_0.Length == 0)
            {
                return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
            }
            Queue<sExpressionToken<T>> queue = new Queue<sExpressionToken<T>>();
            eTokenCharType<T> a = eTokenCharType<T>.a;
            bool flag = false;
            int startIndex = -1;
            for (int i = 0; i < A_0.Length; i++)
            {
                eTokenCharType<T> c = eTokenCharType<T>.c;
                if (flag)
                {
                    flag = false;
                }
                else
                {
                    if (A_0[i] == '\\')
                    {
                        flag = true;
                        continue;
                    }
                    if (ExpressionEvaluator<T>.c.ContainsKey(A_0[i]))
                    {
                        c = ExpressionEvaluator<T>.c[A_0[i]];
                    }
                    if (char.IsWhiteSpace(A_0[i]))
                    {
                        continue;
                    }
                }
                if (((c != a) || (a == eTokenCharType<T>.e)) || (a == eTokenCharType<T>.f))
                {
                    if (a != eTokenCharType<T>.a)
                    {
                        queue.Enqueue(new sExpressionToken<T>(a, A_0.Substring(startIndex, i - startIndex).Trim()));
                    }
                    a = c;
                    startIndex = i;
                }
            }
            queue.Enqueue(new sExpressionToken<T>(a, A_0.Substring(startIndex, A_0.Length - startIndex).Trim()));
            Queue<sExpressionToken<T>> queue2 = new Queue<sExpressionToken<T>>();
            while (queue.Count > 0)
            {
                sExpressionToken<T> item = queue.Dequeue();
                switch (item.a)
                {
                    case eTokenCharType<T>.b:
                        item.c = double.Parse(item.b.Trim(), CultureInfo.InvariantCulture);
                        break;

                    case eTokenCharType<T>.c:
                        sExpressionToken<T> token2;
                        if (this.a(item.b, out token2))
                        {
                            item = token2;
                        }
                        break;
                }
                queue2.Enqueue(item);
            }
            Queue<sExpressionToken<T>> queue3 = new Queue<sExpressionToken<T>>();
            Stack<sExpressionToken<T>> stack = new Stack<sExpressionToken<T>>();
            while (queue2.Count > 0)
            {
                int num3;
                sExpressionToken<T> token3 = queue2.Dequeue();
                switch (token3.a)
                {
                    case eTokenCharType<T>.b:
                    {
                        queue3.Enqueue(token3);
                        continue;
                    }
                    case eTokenCharType<T>.c:
                    {
                        queue3.Enqueue(token3);
                        continue;
                    }
                    case eTokenCharType<T>.d:
                        num3 = token3.a();
                        goto Label_0211;

                    case eTokenCharType<T>.e:
                    {
                        stack.Push(token3);
                        continue;
                    }
                    case eTokenCharType<T>.f:
                        break;

                    default:
                    {
                        continue;
                    }
                }
                while (true)
                {
                    if (stack.Count == 0)
                    {
                        throw new TokenParseError<T>("No matching '(' found");
                    }
                    sExpressionToken<T> token4 = stack.Pop();
                    if (token4.a != eTokenCharType<T>.e)
                    {
                        queue3.Enqueue(token4);
                    }
                }
            Label_0203:
                queue3.Enqueue(stack.Pop());
            Label_0211:
                if (((stack.Count > 0) && (stack.Peek().a == eTokenCharType<T>.d)) && (num3 <= stack.Peek().a()))
                {
                    goto Label_0203;
                }
                stack.Push(token3);
            }
            while (stack.Count > 0)
            {
                sExpressionToken<T> token5 = stack.Pop();
                if (token5.a == eTokenCharType<T>.f)
                {
                    throw new TokenParseError<T>("No matching '(' found");
                }
                if (token5.a == eTokenCharType<T>.e)
                {
                    throw new TokenParseError<T>("No matching ')' found");
                }
                queue3.Enqueue(token5);
            }
            while (queue3.Count > 0)
            {
                sExpressionToken<T> token6 = queue3.Dequeue();
                switch (token6.a)
                {
                    case eTokenCharType<T>.b:
                    case eTokenCharType<T>.c:
                        stack.Push(token6);
                        break;

                    case eTokenCharType<T>.d:
                    {
                        sExpressionToken<T> token7 = stack.Pop();
                        sExpressionToken<T> token8 = stack.Pop();
                        stack.Push(this.a(token8, token7, token6));
                        break;
                    }
                }
            }
            if (stack.Count == 0)
            {
                throw new TokenParseError<T>("No operands");
            }
            if (stack.Count > 1)
            {
                throw new TokenParseError<T>("Operand without intervening operator");
            }
            return stack.Pop();
        }

        public sExpressionToken<T> a(string A_0, out bool A_1)
        {
            try
            {
                this.b = Activator.CreateInstance<T>();
                sExpressionToken<T> token = this.a(A_0);
                A_1 = this.b.a;
                return token;
            }
            catch
            {
                Debug.Print("Unspecified error in spec: \"" + A_0 + "\", ignoring entry.");
                A_1 = true;
                return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
            }
        }

        private bool a(string A_0, out sExpressionToken<T> A_1)
        {
            string key = A_0.ToLowerInvariant().Trim();
            if (this.a.ContainsKey(key))
            {
                object obj2 = this.a[key](this.b);
                if (obj2 == null)
                {
                    A_1 = new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                    return true;
                }
                if (obj2.GetType() == typeof(double))
                {
                    A_1 = new sExpressionToken<T>(eTokenCharType<T>.b, (double) obj2);
                    return true;
                }
                if (obj2.GetType() == typeof(int))
                {
                    A_1 = new sExpressionToken<T>(eTokenCharType<T>.b, (double) ((int) obj2));
                    return true;
                }
                if (obj2.GetType() == typeof(string))
                {
                    A_1 = new sExpressionToken<T>(eTokenCharType<T>.c, (string) obj2);
                    return true;
                }
                A_1 = new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                return true;
            }
            A_1 = new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
            return false;
        }

        public void a(string A_0, delExpressionVariable<T> A_1)
        {
            this.a[A_0.ToLowerInvariant().Trim()] = A_1;
        }

        private sExpressionToken<T> a(sExpressionToken<T> A_0, sExpressionToken<T> A_1, sExpressionToken<T> A_2)
        {
            if ((A_0.a != eTokenCharType<T>.b) || (A_1.a != eTokenCharType<T>.b))
            {
                if ((A_0.a != eTokenCharType<T>.c) || (A_1.a != eTokenCharType<T>.c))
                {
                    throw new TokenParseError<T>("Attempted to compare two disperate types");
                }
                string key = A_2.b;
                if (key != null)
                {
                    int num5;
                    if (bx.d == null)
                    {
                        Dictionary<string, int> dictionary2 = new Dictionary<string, int>(9);
                        dictionary2.Add("==", 0);
                        dictionary2.Add("<", 1);
                        dictionary2.Add(">", 2);
                        dictionary2.Add(">=", 3);
                        dictionary2.Add("<=", 4);
                        dictionary2.Add("!=", 5);
                        dictionary2.Add("+", 6);
                        dictionary2.Add("-", 7);
                        dictionary2.Add("#", 8);
                        bx.d = dictionary2;
                    }
                    if (bx.d.TryGetValue(key, out num5))
                    {
                        switch (num5)
                        {
                            case 0:
                                if (string.Compare(A_0.b, A_1.b, StringComparison.OrdinalIgnoreCase) != 0)
                                {
                                    return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                                }
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);

                            case 1:
                                if (string.Compare(A_0.b, A_1.b, StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                                }
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);

                            case 2:
                                if (string.Compare(A_0.b, A_1.b, StringComparison.OrdinalIgnoreCase) <= 0)
                                {
                                    return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                                }
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);

                            case 3:
                                if (string.Compare(A_0.b, A_1.b, StringComparison.OrdinalIgnoreCase) < 0)
                                {
                                    return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                                }
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);

                            case 4:
                                if (string.Compare(A_0.b, A_1.b, StringComparison.OrdinalIgnoreCase) > 0)
                                {
                                    return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                                }
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);

                            case 5:
                                if (string.Compare(A_0.b, A_1.b, StringComparison.OrdinalIgnoreCase) == 0)
                                {
                                    return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                                }
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);

                            case 6:
                                return new sExpressionToken<T>(eTokenCharType<T>.c, A_0.b + A_1.b);

                            case 7:
                                return new sExpressionToken<T>(eTokenCharType<T>.c, A_0.b + "-" + A_1.b);

                            case 8:
                            {
                                Regex regex = new Regex(A_1.b, RegexOptions.IgnoreCase);
                                if (!regex.IsMatch(A_0.b))
                                {
                                    return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                                }
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);
                            }
                        }
                    }
                }
                throw new TokenParseError<T>("Invalid operator '" + A_2.b + "' for 'String'");
            }
            double c = A_0.c;
            double num2 = A_1.c;
            string b = A_2.b;
            if (b != null)
            {
                int num4;
                if (bx.c == null)
                {
                    Dictionary<string, int> dictionary1 = new Dictionary<string, int>(13);
                    dictionary1.Add("&&", 0);
                    dictionary1.Add("||", 1);
                    dictionary1.Add("==", 2);
                    dictionary1.Add("<", 3);
                    dictionary1.Add(">", 4);
                    dictionary1.Add(">=", 5);
                    dictionary1.Add("<=", 6);
                    dictionary1.Add("!=", 7);
                    dictionary1.Add("+", 8);
                    dictionary1.Add("-", 9);
                    dictionary1.Add("*", 10);
                    dictionary1.Add("/", 11);
                    dictionary1.Add("%", 12);
                    bx.c = dictionary1;
                }
                if (bx.c.TryGetValue(b, out num4))
                {
                    switch (num4)
                    {
                        case 0:
                            if ((c == 0.0) || (num2 == 0.0))
                            {
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                            }
                            return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);

                        case 1:
                            if ((c == 0.0) && (num2 == 0.0))
                            {
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                            }
                            return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);

                        case 2:
                            if (c != num2)
                            {
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                            }
                            return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);

                        case 3:
                            if (c >= num2)
                            {
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                            }
                            return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);

                        case 4:
                            if (c <= num2)
                            {
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                            }
                            return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);

                        case 5:
                            if (c < num2)
                            {
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                            }
                            return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);

                        case 6:
                            if (c > num2)
                            {
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                            }
                            return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);

                        case 7:
                            if (c == num2)
                            {
                                return new sExpressionToken<T>(eTokenCharType<T>.b, 0.0);
                            }
                            return new sExpressionToken<T>(eTokenCharType<T>.b, 1.0);

                        case 8:
                            return new sExpressionToken<T>(eTokenCharType<T>.b, c + num2);

                        case 9:
                            return new sExpressionToken<T>(eTokenCharType<T>.b, c - num2);

                        case 10:
                            return new sExpressionToken<T>(eTokenCharType<T>.b, c * num2);

                        case 11:
                            return new sExpressionToken<T>(eTokenCharType<T>.b, c / num2);

                        case 12:
                            return new sExpressionToken<T>(eTokenCharType<T>.b, (double) (((int) c) % ((int) num2)));
                    }
                }
            }
            throw new TokenParseError<T>("Invalid operator '" + A_2.b + "' for 'Number'");
        }

        private static object b(cv A_0)
        {
            return 1.0;
        }

        public delegate object delExpressionVariable(T A_0);

        public enum eTokenCharType
        {
            public const ExpressionEvaluator<T>.eTokenCharType a = ExpressionEvaluator<T>.eTokenCharType.a;,
            public const ExpressionEvaluator<T>.eTokenCharType b = ExpressionEvaluator<T>.eTokenCharType.b;,
            public const ExpressionEvaluator<T>.eTokenCharType c = ExpressionEvaluator<T>.eTokenCharType.c;,
            public const ExpressionEvaluator<T>.eTokenCharType d = ExpressionEvaluator<T>.eTokenCharType.d;,
            public const ExpressionEvaluator<T>.eTokenCharType e = ExpressionEvaluator<T>.eTokenCharType.e;,
            public const ExpressionEvaluator<T>.eTokenCharType f = ExpressionEvaluator<T>.eTokenCharType.f;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct sExpressionToken
        {
            public ExpressionEvaluator<T>.eTokenCharType a;
            public string b;
            public double c;
            public sExpressionToken(ExpressionEvaluator<T>.eTokenCharType A_0, string A_1)
            {
                this.a = A_0;
                this.b = A_1;
                this.c = 0.0;
            }

            public sExpressionToken(ExpressionEvaluator<T>.eTokenCharType A_0, double A_1)
            {
                this.a = A_0;
                this.c = A_1;
                this.b = "";
            }

            public int a()
            {
                string b = this.b;
                if (b != null)
                {
                    int num;
                    if (bx.e == null)
                    {
                        Dictionary<string, int> dictionary1 = new Dictionary<string, int>(14);
                        dictionary1.Add("&&", 0);
                        dictionary1.Add("||", 1);
                        dictionary1.Add("==", 2);
                        dictionary1.Add("<", 3);
                        dictionary1.Add(">", 4);
                        dictionary1.Add(">=", 5);
                        dictionary1.Add("<=", 6);
                        dictionary1.Add("!=", 7);
                        dictionary1.Add("#", 8);
                        dictionary1.Add("+", 9);
                        dictionary1.Add("-", 10);
                        dictionary1.Add("*", 11);
                        dictionary1.Add("/", 12);
                        dictionary1.Add("%", 13);
                        bx.e = dictionary1;
                    }
                    if (bx.e.TryGetValue(b, out num))
                    {
                        switch (num)
                        {
                            case 0:
                                return -1;

                            case 1:
                                return -1;

                            case 2:
                                return 0;

                            case 3:
                                return 0;

                            case 4:
                                return 0;

                            case 5:
                                return 0;

                            case 6:
                                return 0;

                            case 7:
                                return 0;

                            case 8:
                                return 1;

                            case 9:
                                return 2;

                            case 10:
                                return 2;

                            case 11:
                                return 3;

                            case 12:
                                return 3;

                            case 13:
                                return 3;
                        }
                    }
                }
                throw new ExpressionEvaluator<T>.TokenParseError("Invalid operator '" + this.b + "'");
            }
        }

        private class TokenParseError : Exception
        {
            public TokenParseError(string A_0) : base(A_0)
            {
            }
        }
    }
}

