using System;
using System.Collections.Generic;
using System.Text;

namespace kiswa.Games.Life.DataLayer
{
    /// <summary>
    /// Game of Life simulator.
    /// </summary>
    /// <remarks>
    /// This is a Cellular Automaton simulator which defaults to the rules
    /// for Conway's Game of Life.
    /// The universe is represented by an array of boolean values representing
    /// cell states (true or false for 'alive' or 'dead').
    /// When providing rules, use the format 'survival/birth' where Conway's
    /// rules would be "23/3".  This means a living cell with 2 or 3 neighbors 
    /// will 'survive' and a dead cell with 3 neighbors will be 'born'.
    /// </remarks>
    public sealed class LifeGame
    {
        #region Properties
        /// <summary>
        /// Gets the number of columns in the grid.
        /// </summary>
        public int Columns { get { return _cols; } }
        /// <summary>
        /// Gets the number of rows in the grid.
        /// </summary>
        public int Rows { get { return _rows; } }
        /// <summary>
        /// Gets the number of cells in the grid.
        /// </summary>
        public int Cells { get { return _cells; } }
        /// <summary>
        /// Gets the number of 'alive' cells.
        /// </summary>
        public int LiveCellCount { get { return _liveCells; } }
        /// <summary>
        /// Gets the string representation of the current rules.
        /// </summary>
        public string Rules { get { return _unparsedRules; } }
        /// <summary>
        /// Gets the bool array current state of the simulation.
        /// </summary>
        public bool[] GameGrid { get { return _currentStates; } }
        #endregion

        #region Fields
        private bool[] _currentStates;
        private bool[] _newStates;
        private bool[] _startStates;
        private int _rows;
        private int _cols;
        private int _cells;
        private int _liveCells;
        private List<int> _surviveRules;
        private List<int> _birthRules;
        private string _unparsedRules;
        #endregion

        #region Public Constructors
        /// <summary>
        /// Constructor for a Game of Life Simulator.
        /// </summary>
        /// <param name="gridSize">Size of one side of the grid - 
        /// used for both to create a square grid.</param>
        public LifeGame(int gridSize)
            : this(gridSize, gridSize, "23/3")
        {
            // Called ctor with default rules
        }

        /// <summary>
        /// Constructor for a Game of Life Simulator.
        /// </summary>
        /// <param name="columns">Number of columns in the grid.</param>
        /// <param name="rows">Number of rows in the grid.</param>
        public LifeGame(int columns, int rows)
            : this(columns, rows, "23/3")
        {
            // Called ctor with default rules
        }

        /// <summary>
        /// Constructor for a Game of Life Simulator.
        /// </summary>
        /// <param name="columns">Number of columns in the grid.</param>
        /// <param name="rows">Number of rows in the grid.</param>
        /// <param name="rules">String representing the GoL ruleset to use
        /// (e.g. "23/3" for Conway's Life).</param>
        public LifeGame(int columns, int rows, string rules)
        {
            _cols = columns;
            _rows = rows;
            _cells = columns * rows;

            ClearGrid();
            _startStates = new bool[_cells];
            ChangeRules(rules);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Allows changing of ruleset.
        /// </summary>
        /// <param name="rules">String representing the ruleset to use.</param>
        /// <remarks>When invalid rules are input, rules default to 23/3.</remarks>
        public void ChangeRules(string rules)
        {
            if (rules.Contains("9") || !rules.Contains("/"))
            { rules = "23/3"; }

            _unparsedRules = rules;
            string survive = rules.Split('/')[0];
            string birth = rules.Split('/')[1];

            _surviveRules = new List<int>();
            _birthRules = new List<int>();

            for (int i = 0; i < survive.Length; i++)
            {
                _surviveRules.Add(Int32.Parse(survive.Substring(i, 1)));
            }
            for (int i = 0; i < birth.Length; i++)
            {
                _birthRules.Add(Int32.Parse(birth.Substring(i, 1)));
            }
        }

        /// <summary>
        /// Clears the grid.
        /// </summary>
        public void ClearGrid()
        {
            _liveCells = 0;
            _currentStates = new bool[_cells];
            _newStates = new bool[_cells];
        }

        /// <summary>
        /// Randomly creates live cells in the grid.
        /// </summary>
        /// <param name="probability">Probability of cell creation (0.0=all dead, 1.0=all alive).</param>
        public void Randomize(double probability)
        {
            Random rand = new Random();
            _liveCells = 0;
            for (int i = 0; i < _cells; i++)
            {
                _currentStates[i] = rand.NextDouble() <= probability;
                if (_currentStates[i])
                { _liveCells += 1; }
            }
        }

        /// <summary>
        /// Resets the grid to the saved starting state.
        /// </summary>
        public void ResetGrid()
        {
            _startStates.CopyTo(_currentStates, 0);
        }

        /// <summary>
        /// Saves the grid state for reset.
        /// </summary>
        public void SetStart()
        {
            _currentStates.CopyTo(_startStates, 0);
        }

        /// <summary>
        /// Steps through one generation of the grid.
        /// </summary>
        public void Step()
        {
            advancePopulation();
            _newStates.CopyTo(_currentStates, 0);
        }

        /// <summary>
        /// Gets the state of the specified cell.
        /// </summary>
        /// <param name="x">Column location of the cell to test.</param>
        /// <param name="y">Row location of the cell to test.</param>
        /// <returns>True or false for cell 'alive' or 'dead'.</returns>
        public bool GetCellState(int x, int y)
        {
            if (y < 0 || y >= _rows || x < 0 || x >= _cols)
            { return false; }
            
            return _currentStates[x + y * _cols];
        }

        /// <summary>
        /// Swaps the state of the specified cell.
        /// </summary>
        /// <param name="x">Column location of the cell to alter.</param>
        /// <param name="y">Row location of the cell to alter.</param>
        public void ToggleCellState(int x, int y)
        {
            if (y < 0 || y >= _rows || x < 0 || x >= _cols)
            { return; }

            int index = x + y * _cols;
            _currentStates[index] = !(_currentStates[index]);
            
            if (_currentStates[index])
            { _liveCells += 1; }
            else
            { _liveCells -= 1; }
        }

        /// <summary>
        /// Converts the grid to a string representation.
        /// For 'dead' cells uses ".", for 'alive' cells uses "*".
        /// </summary>
        /// <returns>String representation of the grid.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _cols; x++)
                {
                    sb.Append(_currentStates[x + y * _cols] ? '*' : '.');
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Advances the entire population by one generation.
        /// </summary>
        private void advancePopulation()
        {
            if (_liveCells == 0)
            { return; }

            _liveCells = 0;
            int neighbors;
            int index;
            bool alive;

            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _cols; x++)
                {
                    neighbors = getNeighbors(x, y);
                    index = x + y * _cols;
                    alive = _currentStates[index];

                    // If cell is alive and survives, or dead and is born
                    if ((alive && _surviveRules.Contains(neighbors)) ||
                        (!alive && _birthRules.Contains(neighbors)))
                    {
                        _newStates[index] = true;
                        _liveCells += 1;
                    }
                    else // The cell neither survives nor is born
                    { _newStates[index] = false; }
                }
            }
        }

        /// <summary>
        /// Gets the count of live neighbors for a specified cell.
        /// </summary>
        /// <param name="x">Column location of the cell to test.</param>
        /// <param name="y">Row location of the cell to test.</param>
        /// <returns>Integer value of live neighbors.</returns>
        private int getNeighbors(int x, int y)
        {
            int neighborCount = 0;
            
/* NW */    if ((x > 0 && y > 0) && _currentStates[x - 1 + (y - 1) * _cols])
            { neighborCount += 1; }
/* N  */    if ((y > 0) && _currentStates[x + (y - 1) * _cols])
            { neighborCount += 1; }
/* NE */    if ((x + 1 < _cols && y > 0) && _currentStates[x + 1 + (y - 1) * _cols])
            { neighborCount += 1; }
/* W  */    if ((x + 1 < _cols) && _currentStates[x + 1 + y * _cols])
            { neighborCount += 1; }
/* SW */    if ((x + 1 < _cols && y + 1 < _rows) && _currentStates[x + 1 + (y + 1) * _cols])
            { neighborCount += 1; }
/* S  */    if ((y + 1 < _rows) && _currentStates[x + (y + 1) * _cols])
            { neighborCount += 1; }
/* SE */    if ((x > 0 && y + 1 < _rows) && _currentStates[x - 1 + (y + 1) * _cols])
            { neighborCount += 1; }
/* E  */    if ((x > 0) && _currentStates[x - 1 + y * _cols])
            { neighborCount += 1; }

            return neighborCount;
        }
        #endregion
    }
}