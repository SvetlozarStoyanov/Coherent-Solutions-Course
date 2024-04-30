namespace Homework_2
{
    public class Point
    {
        private double mass;
        private int[] coordinates;

        public Point()
        {
            coordinates = new int[3];
        }

        public Point(int x, int y, int z, double mass) : this()
        {
            X = x;
            Y = y;
            Z = z;
            Mass = mass;
        }
        public int X
        {
            get => coordinates[0];
            set => coordinates[0] = value;
        }
        public int Y
        {
            get => coordinates[1];
            set => coordinates[1] = value;
        }
        public int Z
        {
            get => coordinates[2];
            set => coordinates[2] = value;
        }
        public double Mass
        {
            get => mass;
            set
            {
                if (value < 0)
                {
                    mass = 0;
                }
                else
                {
                    mass = value;
                }
            }
        }
        public bool IsZero()
        {
            return X == 0 && Y == 0 && Z == 0;
        }

        public double Distance(Point point)
        {
            var distance = Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2) + Math.Pow(point.Z - Z, 2));
            // in case distance has to be rounded
            //distance = Math.Round(distance);
            return distance;
        }
    }
}
