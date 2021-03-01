using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask_figures
{
    abstract class Figure
    {
        public abstract void ShowInfo();
        public abstract double getSquare();
    }


    class Circle: Figure
    {
        private double radius;
        private string name = "Круг";
        
        public override void ShowInfo()
        {
            Console.WriteLine("Фигура: " + name + "\nРадиус: " + radius);
        } 
        public Circle(){ }

        public bool SetRadius(double r)
        {
            if (r > 0)
            {
                this.radius = r;
                return true;
            }
            else
            {
                Console.WriteLine("Неправильный радиус");
                return false;
            }
        }

        public override double getSquare()
        {
            return Math.PI * Math.Pow(radius, (int)2);
        }
    }


    class Triangle : Figure
    {
        private double A, B, C;
        private string name = "Треугольник";

        public override void ShowInfo()
        {
            if (A == Math.Sqrt(Math.Pow(B, (int)2) + Math.Pow(C, (int)2)) || B == Math.Sqrt(Math.Pow(A, (int)2) + Math.Pow(C, (int)2)) || C == Math.Sqrt(Math.Pow(B, (int)2) + Math.Pow(A, (int)2)))
            {
                Console.WriteLine("Фигура: " + name + "\nСтороны: A=" + A + " B=" + B + " C=" + C + "\nПрямоугольный");
            } 
            else
            {
                Console.WriteLine("Фигура: " + name + "\nСтороны: A=" + A + " B=" + B + " C=" + C+ "\nНе прямоугольный");
            }
            
        }

        public Triangle() { }

        public Triangle(double a, double b, double c)
        {
            this.setABC(a, b, c);
        }

        public bool setABC(double a, double b, double c)
        {
            if (a > 0 && b>0 && c > 0)
            {
                if(a+b>c && a+c>b && c + b > a)
                {
                    A = a; B = b; C = c;
                    return true;
                }
                else
                {
                    Console.WriteLine("Ошибка:: Такой треугольник не существует");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Ошибка:: Одна из сторон меньше или равна нулю");
                return false;
            }
        }

        public override double getSquare()
        {
            double p= (A + B + C) / 2;

            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

    }


    class OtherFigure : Figure
    {
        private List<double> coords;
        private string name = "Пользовательская";

        public OtherFigure() {
            coords = new List<double>();
        }
        public override void ShowInfo()
        {
            Console.WriteLine("Фигура: " + name);
        }

        public void setCoords()
        {
            int coordsCount;
            Console.WriteLine("Сколько вершин у данной фигуры?");
            coordsCount=Convert.ToInt32(Console.ReadLine());

            for(int i=0; i<coordsCount; i++)
            {
                while (true)
                {
                    Console.WriteLine("Координата №" + (int)(i + 1));
                    Console.WriteLine("Введите x и y через пробел");

                    string XY = Console.ReadLine();
                    string[] buff = XY.Split(' ');
                    try
                    {
                        double x = Convert.ToDouble(buff[0]);
                        double y = Convert.ToDouble(buff[1]);
                        coords.Add(x);
                        coords.Add(y);
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Что-то пошло не так, попробуйте еще раз");
                    }
                }
            }
        }

        public override double getSquare()
        {
            double h1=0;
            double h2 = 0;
            for(int i=0; i<coords.Count-2; i++)
            {
                if (i % 2 == 0)
                {
                    h1 += coords[i] * coords[i + 3];
                }
                else
                {
                    h2 += coords[i] * coords[i + 1];
                }
            }
            h1 += coords[coords.Count - 2] * coords[1];
            h2 += coords[coords.Count - 1] * coords[0];

            return (h1 - h2) / 2;
        }


    }


    //interface IFigure { }

    //interface ICircleSquare
    //{
    //    double getCircleSquare();
    //}

    //interface ITriangleSquare
    //{
    //    double getTriangleSquare();
    //}

    //class Circle2 : IFigure, ICircleSquare
    //{

    //}


}
