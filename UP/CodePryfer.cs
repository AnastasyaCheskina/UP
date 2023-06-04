using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP
{
    internal class CodePryfer
    {
        public static void StartCode()
        {
            GetAnswerCode();
        }
        public static void StartDecode() //считывание из файла, декодирование, запись в другой файл
        {
            Console.WriteLine("Код Прюфера:");
            int[] code = GetCodeAtFile("CodePryfer.txt"); //путь к файлу с кодом прюфера
            if (code != null)
            {
                ShowArr1(code);
                int[,] result = GetAnswerDecode(code);
                Console.WriteLine("Список ребер:");
                ShowArr2(result);
                WriteEdgeAtFile("DecodeResult.txt", result);
            }
            else Console.WriteLine("Данную задачу нельзя решить");
        }
        private static void ShowArr2(int[,] arr) //вывод двумерного массива
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        private static void ShowArr1(int[] arr) //вывод одномерного массива
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        private static int[] GetCodeAtFile(string file) //получить код Прюфера из файла
        {
            List<int> ints = new List<int>();
            string allData = File.ReadAllLines(file).First();
            for (int i = 0; i < allData.Length; i++)
            {
                ints.Add((int)Char.GetNumericValue(allData[i]));
            }
            int[] code = new int[ints.Count];
            int j = 0;
            foreach (int i in ints)
            {
                code[j] = i;
                j++;
            }
            return code;
        }
        private static void WriteEdgeAtFile(string path, int[,] edge) //запись списка ребер в файл
        {
            using (StreamWriter f = new StreamWriter(path, true))
            {
                for (int i = 0; i < edge.GetLength(0); i++)
                {
                    for (int j = 0; j < edge.GetLength(1); j++)
                    {
                        f.Write(edge[i, j] + " ");
                    }
                    f.Write('\n');
                }
            }
        }
        private static int[,] GetAnswerDecode(int[] arr) //алгоритм декодирования
        {
            List<int> inputData = new List<int>(); //лист с кодом прюфера
            for (int i = 0; i < arr.Length; i++)
            {
                inputData.Add(arr[i]);
            }
            int countEdge = inputData.Count + 2; //кол-во вершин
            List<int> vertices = new List<int>(); //лист с вершинами
            for (int i = 1; i <= countEdge; i++)
            {
                vertices.Add(i);
            }
            int[,] answerArray = new int[2, countEdge - 1]; //двумерный массив ребер (ответы)
            if (inputData.Count > 0)
            {
                for (int i = 0; i < answerArray.GetLength(1); i++)
                {
                    if (inputData.Count > 0)
                    {
                        var b = inputData.First(); //получаем первое число в коде прюфера
                        answerArray[0, i] = b; //задаем начало ребра - первое число из кода прюфера
                        inputData.Remove(b); //удаляем из кода первое число
                        var items = vertices.Except(inputData).ToList(); //выборка тех вершин, которые не содержатся в коде прюфера
                        items.Remove(b); //удаляем из них используемую нами вершину
                        var a = items.First(); //выбираем первую вершину из возможных
                        if (answerArray[0, i] != a)
                        {
                            answerArray[1, i] = a; //записываем её в ответ
                            vertices.Remove(a); //удаляем вершину из списка
                        }
                    }
                    else break;
                }
                for (int i = 0; i < 2; i++) //добавляем в ответ оставшиеся две вершины
                {
                    answerArray[i, countEdge - 2] = vertices[i];
                }
                return answerArray;
            }
            else return null;
        }
        private static void GetAnswerCode()
        {
            int[,] enterData = { { 1, 5, 2, 6, 6, 2, 1, 3, 3 }, { 4, 7, 5, 8, 9, 6, 2, 1, 10 } };
            List<int> str1 = new List<int>();
            List<int> str2 = new List<int>();
            List<int> copyStr1 = new List<int>();
            List<int> copyStr2 = new List<int>();
            List<int> code = new List<int>();
            int min = int.MaxValue;
            int minInd = 0;
            List<int> copy1 = str1;
            for (int j = 0; j < enterData.GetLength(1); j++)
            {
                str1.Add(enterData[0, j]); //преобразуем входной массив в лист по разным строкам
                str2.Add(enterData[1, j]);
            }
            while (str1.Count > 1)
            {
                for (int i = 0; i < str2.Count; i++)
                {
                    if (copy1.Contains(str2[i])) //если в первой строке содержится число из второй, то удаляем это ребро, оно не учитывается
                    {
                        //также запоминаем эти ребра для дальнейшего их объединения заново
                        str1.Remove(str1[i]);
                        str2.Remove(str2[i]);
                        copyStr1.Add(str1[i]); //тут хранятся не учитывающиеся вершины
                        copyStr2.Add(str2[i]);
                    }
                }
                for (int i = 0; i < str2.Count; i++) //ищем минимальное число во 2 строке
                {
                    if (str2[i] < min)
                    {
                        min = str2[i];
                        minInd = i;
                    }
                }
                code.Add(str1[minInd]);
                for (int i = 0; i < str2.Count; i++)
                {
                    str1.Remove(str1[minInd]);
                    str2.Remove(str2[minInd]);
                    str1.AddRange(copyStr1);
                    str2.AddRange(copyStr2);
                    copyStr1.Clear();
                    copyStr2.Clear();
                }
                min = int.MaxValue;
                minInd = 0;
            }
            foreach (int str in code)
            {
                Console.WriteLine(str);
            }
        }
    }
}
