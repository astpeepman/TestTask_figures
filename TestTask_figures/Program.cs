using System;

namespace TestTask_figures
{

    public class Program
    {
        static string defaultError = new string("Что-то пошло не так, попробуйте еще раз!");
        static int ShowMenu()
        {
            string text = "\n----------------------\nВыберите нужный пункт:\n" +
                "1. Вычислить площадь круга\n" +
                "2. Вычислить прощадь треугольника\n" +
                "3. Вычислить площадь произвольного многоугольника (по координатам)";
            Console.WriteLine(text);
            int result;
            try { result = Convert.ToInt32(Console.ReadLine()); } catch { result = -1; }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            

            while (true)
            {
                switch (ShowMenu())
                {
                    case 1:
                        {
                            while (true)
                            {
                                Console.WriteLine("Введите радиус");
                                double r;
                                try
                                {
                                    r = Convert.ToDouble(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine(defaultError);
                                    continue;
                                }
                                Circle circle = new Circle();
                                if (circle.SetRadius(r))
                                {
                                    circle.ShowInfo();
                                    Console.WriteLine("Площадь фигуры: " + circle.getSquare());
                                    break;

                                }
                            }
                            break;
                        }

                    case 2:
                        {
                            while (true)
                            {
                                Console.WriteLine("Введите стороны треугольника через пробел");
                                string ABC = Console.ReadLine();
                                string[] buff = ABC.Split(' ');
                                double a, b, c;
                                try {
                                    
                                    a = Convert.ToDouble(buff[0]);
                                    b = Convert.ToDouble(buff[1]);
                                    c = Convert.ToDouble(buff[2]);
                                    
                                }
                                catch {
                                    Console.WriteLine(defaultError);
                                    continue;
                                }
                                Triangle triangle = new Triangle();
                                if (triangle.setABC(a, b, c))
                                {
                                    triangle.ShowInfo();
                                    Console.WriteLine("Площадь фигуры: " + triangle.getSquare());
                                    break;
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            
                            OtherFigure myFigure = new OtherFigure();
                            myFigure.setCoords();
                            myFigure.ShowInfo();
                            Console.WriteLine("Площадь фигуры: " + myFigure.getSquare());
                            
                            break;
                        }

                    case -1:
                        {
                            Console.WriteLine(defaultError);
                            break;
                        }

                }
            }

        }
    }
}
