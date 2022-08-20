namespace GaussianElimination
{
    internal class Program
    {
        static double[,] ConvertMatrix(int n, double[,] matrix)
        {
            double[,] uMatrix = new double[n, n]; //單位矩陣

            for (int i = 0; i < n; i++)
            {
                uMatrix[i, i] = 1; //建立單位矩陣
            }

            for (int i = 0; i < n; i++) //i = 正在做的那一列
            {
                var uArray = new double[n]; //"做的那一列"的單位矩陣之陣列映射
                var mArray = new double[n]; //"做的那一列"的原矩陣之陣列映射


                for (int j = 0; j < n; j++)
                {
                    uArray[j] = uMatrix[i, j]; //建立"做的那一列"的單位矩陣之陣列映射
                    mArray[j] = matrix[i, j]; //建立"做的那一列"的原矩陣之陣列映射
                }

                for (int j = 0; j < n; j++)
                {
                    if (j == i)
                    {
                        continue; //如果j=做的那一列 則跳過此次迴圈
                    }
                    else
                    {
                        double multiple = -(matrix[j, i] / matrix[i, i]); //要乘上的倍率

                        for (int k = 0; k < n; k++) //j是row k是column
                        {

                            matrix[j, k] += mArray[k] * multiple;

                            uMatrix[j, k] += uArray[k] * multiple;
                        }
                    }
                }
            }

            //到這邊時，原矩陣會變為上下三角矩陣，下面只要再把各個row除以matrix[i, i]就完成了

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    uMatrix[i, j] /= matrix[i, i];
                }
            }

            return uMatrix;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("請輸入矩陣階層數，輸入完按下Enter");

            int n = Convert.ToInt32(Console.ReadLine());
            double[,] inputMatrix = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"請輸入第 {i + 1} 列矩陣元素，並以半形空白隔開，輸入完按下Enter");

                var row = Console.ReadLine().Split(' ');

                if (row.Length != n)
                {
                    Console.WriteLine($"請輸入 {n} 個數字");

                    i--;
                }
                else
                {
                    foreach (var item in row.Select((value, index) => new { value, index }))
                    {
                        inputMatrix[i, item.index] = Convert.ToDouble(item.value);
                    }
                }

            }

            var result = ConvertMatrix(n, inputMatrix);

            Console.WriteLine("\n---------------Result---------------\n");

            for (int i = 0; i < n; i++)
            {
                Console.Write("[ ");

                for (int j = 0; j < n; j++)
                {
                    if (j == n - 1)
                    {
                        Console.Write($"{Math.Round(result[i, j], 2)}".PadLeft(5));
                        break;
                    }

                    Console.Write($"{Math.Round(result[i, j], 2)}, ".PadLeft(7));
                }

                Console.Write(" ]");
                Console.WriteLine("");
            }

            Console.ReadLine();
        }
    }
}