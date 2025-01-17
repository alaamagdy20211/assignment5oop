namespace assignment5oop
{
    //class Point3D : IComparable, ICloneable
    //{
    //    private int x, y, z;


    //    public Point3D() : this(0, 0, 0) { }

    //    public Point3D(int x) : this(x, 0, 0) { }

    //    public Point3D(int x, int y) : this(x, y, 0) { }

    //    public Point3D(int x, int y, int z)
    //    {
    //        this.x = x;
    //        this.y = y;
    //        this.z = z;
    //    }


    //    public override string ToString()
    //    {
    //        return $"Point Coordinates: ({x}, {y}, {z})";
    //    }


    //    public static bool operator ==(Point3D p1, Point3D p2)
    //    {
    //        if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
    //            return ReferenceEquals(p1, p2);
    //        return p1.x == p2.x && p1.y == p2.y && p1.z == p2.z;
    //    }

    //    public static bool operator !=(Point3D p1, Point3D p2)
    //    {
    //        return !(p1 == p2);
    //    }

    //    public override bool Equals(object obj)
    //    {
    //        if (obj is Point3D other)
    //            return this == other;
    //        return false;
    //    }

    //    public override int GetHashCode()
    //    {
    //        return (x, y, z).GetHashCode();
    //    }


    //    public int CompareTo(object obj)
    //    {
    //        if (obj is Point3D other)
    //        {
    //            if (x != other.x) return x.CompareTo(other.x);
    //            return y.CompareTo(other.y);
    //        }
    //        throw new ArgumentException("Object is not a Point3D");
    //    }


    //    public object Clone()
    //    {
    //        return new Point3D(x, y, z);
    //    }
    //}
    //class Maths
    //{

    //    public static int Add(int a, int b)
    //    {
    //        return a + b;
    //    }


    //    public static int Subtract(int a, int b)
    //    {
    //        return a - b;
    //    }


    //    public static int Multiply(int a, int b)
    //    {
    //        return a * b;
    //    }


    //    public static double Divide(int a, int b)
    //    {
    //        if (b == 0)
    //        {
    //            throw new DivideByZeroException("Cannot divide by zero.");
    //        }
    //        return (double)a / b;
    //    }
    //}

    class Duration
    {
        private int hours;
        private int minutes;
        private int seconds;

        public Duration(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            Normalize();
        }

        public Duration(int totalSeconds)
        {
            hours = totalSeconds / 3600;
            minutes = (totalSeconds % 3600) / 60;
            seconds = totalSeconds % 60;
        }

        public override string ToString()
        {
            return $"Hours: {hours}, Minutes: {minutes}, Seconds: {seconds}";
        }


        public override bool Equals(object obj)
        {
            if (obj is Duration other)
            {
                return hours == other.hours && minutes == other.minutes && seconds == other.seconds;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (hours, minutes, seconds).GetHashCode();
        }

        private void Normalize()
        {
            minutes += seconds / 60;
            seconds %= 60;
            hours += minutes / 60;
            minutes %= 60;
        }

        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration(d1.hours + d2.hours, d1.minutes + d2.minutes, d1.seconds + d2.seconds);
        }

        public static Duration operator +(Duration d, int seconds)
        {
            return new Duration(d.ToTotalSeconds() + seconds);
        }

        public static Duration operator +(int seconds, Duration d)
        {
            return d + seconds;
        }

        public static Duration operator -(Duration d1, Duration d2)
        {
            return new Duration(d1.ToTotalSeconds() - d2.ToTotalSeconds());
        }

        public static Duration operator ++(Duration d)
        {
            return new Duration(d.hours, d.minutes + 1, d.seconds);
        }

        public static Duration operator --(Duration d)
        {
            return new Duration(d.hours, d.minutes - 1, d.seconds);
        }


        public static bool operator >(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() > d2.ToTotalSeconds();
        }


        public static bool operator <(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() < d2.ToTotalSeconds();
        }

        public static bool operator >=(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() >= d2.ToTotalSeconds();
        }


        public static bool operator <=(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() <= d2.ToTotalSeconds();
        }



        public static bool operator -(Duration d)
        {
            return d.ToTotalSeconds() > 0;
        }
        private int ToTotalSeconds()
        {
            return hours * 3600 + minutes * 60 + seconds;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //    try
            //    {
            //        Console.WriteLine("Enter coordinates for Point1 (x y z):");
            //        string[] input1 = Console.ReadLine().Split();
            //        int x1 = int.Parse(input1[0]);
            //        int y1 = int.Parse(input1[1]);
            //        int z1 = int.Parse(input1[2]);

            //        Console.WriteLine("Enter coordinates for Point2 (x y z):");
            //        string[] input2 = Console.ReadLine().Split();
            //        int x2 = int.Parse(input2[0]);
            //        int y2 = int.Parse(input2[1]);
            //        int z2 = int.Parse(input2[2]);

            //        Point3D p1 = new Point3D(x1, y1, z1);
            //        Point3D p2 = new Point3D(x2, y2, z2);

            //        Console.WriteLine(p1);
            //        Console.WriteLine(p2);

            //        Console.WriteLine(p1 == p2 ? "Points are equal." : "Points are not equal.");

            //        Point3D[] points = { p1, p2, new Point3D(5, 5, 5), new Point3D(1, 1, 1) };
            //        Array.Sort(points);

            //        Console.WriteLine("Sorted Points:");
            //        foreach (var point in points)
            //        {
            //            Console.WriteLine(point);
            //        }

            //        Point3D clonedPoint = (Point3D)p1.Clone();
            //        Console.WriteLine($"Cloned Point: {clonedPoint}");
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("Invalid input. Please enter integer values.");
            //    }

            //int num1 = 20, num2 = 10;

            //Console.WriteLine($"Add: {Maths.Add(num1, num2)}");        
            //Console.WriteLine($"Subtract: {Maths.Subtract(num1, num2)}"); 
            //Console.WriteLine($"Multiply: {Maths.Multiply(num1, num2)}"); 
            //Console.WriteLine($"Divide: {Maths.Divide(num1, num2)}");
            Duration D1 = new Duration(1, 10, 15);
            Console.WriteLine(D1.ToString());

            Duration D2 = new Duration(3600);
            Console.WriteLine(D2.ToString());

            Duration D3 = new Duration(7800);
            Console.WriteLine(D3.ToString());

            Duration D4 = new Duration(666);
            Console.WriteLine(D4.ToString());

            // Operators
            D3 = D1 + D2;
            Console.WriteLine(D3.ToString());

            D3 = D1 + 7800;
            Console.WriteLine(D3.ToString());

            D3 = 666 + D3;
            Console.WriteLine(D3.ToString());

            D3 = ++D1;
            Console.WriteLine(D3.ToString());

            D3 = --D2;
            Console.WriteLine(D3.ToString());

            D1 = D1 - D2;
            Console.WriteLine(D1.ToString());

            if (D1 > D2)
                Console.WriteLine("D1 is greater than D2.");
            else
                Console.WriteLine("D1 is not greater than D2.");

            if (D1 <= D2)
                Console.WriteLine("D1 is less than or equal to D2.");

            if (-D1)
                Console.WriteLine("D1 is non-zero.");


        }
    }
}

