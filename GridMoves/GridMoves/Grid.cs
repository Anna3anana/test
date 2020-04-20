using System;
using System.Collections.Generic;

namespace GridMoves
{
    /// <summary>
    /// 2020-04-20 by Anna Eliasson
    /// Test console app for Skymill.
    /// </summary>

    public enum Directions // Usually puts into its own file, but it's such a small enum list so this can be here.
    {
        north,
        east,
        south,
        west
    }
    class Grid
    {
        private readonly int _n;
        private readonly int _m;
        private Directions _directions; // Declaring the enum Directions
        private Coordinate _coordinate;
        private string[,] _gridArray;

        public Grid(List<int> listInput) //Constructor
        {
            this._n = listInput[0];
            this._m = listInput[1];
            _coordinate = new Coordinate(listInput[2], listInput[3]); // New instance of coordinate, passing x and y

            _gridArray = CreateArray(); //Passing
            _directions = Directions.north; // Setting the starting direction as north
        }
        //public string[,] GridArray { get; set; }

        private string[,] CreateArray() // Create the array of the coordinates of the grid and the object
        {
            string[,] array = new string[_n, _m];
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _m; j++)
                {
                    array[i, j] = _coordinate.X == j && _coordinate.Y == i ? "+" : "."; // The object gets the X & Y coordinates and is an "+", the rest are ".".
                }
            }
            return array;
        }
        public void PlotGrid() // Method to plot the grid.
        {
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _m; j++)
                {
                    Console.Write(string.Format("{0} ", _gridArray[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
        public void UpdateDirections(int key) // Method to update the direction(rotate object) and passing an integer.
        {
            switch (_directions)
            {
                case Directions.north:
                    _directions = key == 3 ? Directions.east : Directions.west; // If 3 = clockwise rotation else 4 = counterclockwise.
                    break;
                case Directions.east:
                    _directions = key == 3 ? Directions.south : Directions.north;
                    break;
                case Directions.south:
                    _directions = key == 3 ? Directions.west : Directions.east;
                    break;
                case Directions.west:
                    _directions = key == 3 ? Directions.north : Directions.south;
                    break;
                default:
                    break;
            }
            _gridArray = CreateArray();
            PlotGrid();
            Console.WriteLine("Rotation of the object has been done, please submit another command.");
        }
        public void UpdateGrid(int key) // Method to update the grid and passing an integer.
        {
            switch (_directions)
            {
                case Directions.north:
                    _coordinate.Y = key == 1 ? _coordinate.Y - 1 : _coordinate.Y + 1;
                    break;
                case Directions.east:
                    _coordinate.X = key == 1 ? _coordinate.X + 1 : _coordinate.X - 1;
                    break;
                case Directions.south:
                    _coordinate.Y = key == 1 ? _coordinate.Y + 1 : _coordinate.Y - 1;
                    break;
                case Directions.west:
                    _coordinate.X = key == 1 ? _coordinate.X - 1 : _coordinate.X + 1;
                    break;
                default:
                    break;
            }
            // Validation below if object is within the grid, otherwise move back the object to the grid.
            if (_coordinate.Y == _m)
            {
                Console.WriteLine("Y is larger than M, can not make a move outside the grid");
                _coordinate.Y = _coordinate.Y - 1;
            }
            if (_coordinate.Y < 0)
            {
                Console.WriteLine("Y is smaller than M, can not make a move outside the grid");
                _coordinate.Y = _coordinate.Y + 1;
            }
            if (_coordinate.X == _n)
            {
                Console.WriteLine("X is larger than N, can not make a move outside the grid");
                _coordinate.X = _coordinate.X - 1;
            }
            if (_coordinate.X < 0)
            {
                Console.WriteLine("X is smaller than N, can not make a move outside the grid");
                _coordinate.X = _coordinate.X + 1;
            }
            _gridArray = CreateArray();
            PlotGrid();
        }
    }
    class Coordinate
    {
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
