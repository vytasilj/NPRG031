using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace kiswa.Games.Life.CustomControls
{
    /// <summary>
    /// Grid control for displaying a LifeGame simulation.
    /// </summary>
    public sealed partial class LifeGrid : UserControl
    {
        #region Properties
        /// <summary>
        /// Gets or Sets the color of alive cells.
        /// </summary>
        [Category("LifeGrid"),
        Description("Color for living cells."),
        DefaultValue(typeof(Color), "Black")]
        public Color CellColorAlive
        {
            get { return _cellColorAlive; }
            set { _cellColorAlive = value; Invalidate(); }
        }
        /// <summary>
        /// Gets or Sets the color of dead cells.
        /// </summary>
        [Category("LifeGrid"),
        Description("Color for dead cells."),
        DefaultValue(typeof(Color),"White")]
        public Color CellColorDead
        {
            get { return _cellColorDead; }
            set { _cellColorDead = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or Sets the number of rows in the grid.
        /// </summary>
        [Category("LifeGrid"),
        Description("Number of Rows."),
        DefaultValue(100)]
        public int Rows
        {
            get { return _rows; }
            set { _rows = value; createGrid(); }
        }
        /// <summary>
        /// Gets or Sets the number of columns in the grid.
        /// </summary>
        [Category("LifeGrid"),
        Description("Number of Columns."),
        DefaultValue(100)]
        public int Columns
        {
            get { return _cols; }
            set { _cols = value; createGrid(); }
        }

        /// <summary>
        /// Gets or Sets whether grid lines are visible.
        /// </summary>
        [Category("LifeGrid"),
        Description("Whether or not lines are displayed."),
        DefaultValue(true)]
        public bool LinesVisible
        {
            get { return _gridLinesVisible; }
            set { _gridLinesVisible = value; Invalidate(); }
        }
        /// <summary>
        /// Gets or Sets the line thickness for grid lines.
        /// </summary>
        [Category("LifeGrid"),
        Description("Thickness of lines when displayed."),
        DefaultValue(1)]
        public float LinesSize
        {
            get { return _gridLineThickness; }
            set { _gridLineThickness = value; Invalidate(); }
        }
        #endregion

        #region Fields
        private bool[] _gridStates = new bool[100*100];

        private bool _gridLinesVisible;
        private float _gridLineThickness;

        private int _rows;
        private int _cols;

        private Color _cellColorAlive;
        private Color _cellColorDead;
        #endregion

        #region Public Constructors
        /// <summary>
        /// Creates a LifeGrid with defaults of 100x100
        /// for the grid size, black for alive cells and
        /// white for dead cells.
        /// </summary>
        public LifeGrid() : this(100, 100, Color.Black, Color.White) { }
        /// <summary>
        /// Creates a LifeGrid with the specified grid size
        /// and default black for alive cells and white for dead cells.
        /// </summary>
        /// <param name="cols">Number of columns in the grid.</param>
        /// <param name="rows">Number of rows in the grid.</param>
        public LifeGrid(int cols, int rows) : this(cols, rows, Color.Black, Color.White) { }
        /// <summary>
        /// Creates a LifeGrid with the specified grid size
        /// and cell alive and dead colors.
        /// </summary>
        /// <param name="cols">Number of columns in the grid.</param>
        /// <param name="rows">Number of rows in the grid.</param>
        /// <param name="aliveColor">Color for alive cells.</param>
        /// <param name="deadColor">Color for dead cells.</param>
        public LifeGrid(int cols, int rows, Color aliveColor, Color deadColor)
        {
            InitializeComponent();
            DoubleBuffered = true;
            TabStop = false;

            _cols = cols;
            _rows = rows;
            _gridLineThickness = 1;
            _gridLinesVisible = true;

            _cellColorAlive = aliveColor;
            _cellColorDead = deadColor;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Updates the display grid with the provided grid states.
        /// </summary>
        /// <param name="gridStates">Grid states to copy.</param>
        /// <exception cref="InvalidOperationException">Thrown if grid sizes do not match.</exception>
        public void UpdateGrid(bool[] gridStates)
        {
            if (gridStates.Length == _gridStates.Length)
            {
                gridStates.CopyTo(_gridStates, 0);
                Invalidate();
            }
            else
            {
                throw new InvalidOperationException("Grid sizes do not match.");
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Called by Rows and Cols Properties when Set,
        /// to update the control in design view.
        /// </summary>
        private void createGrid()
        {
            _gridStates = new bool[_cols * _rows];
            Invalidate();
        }
        #endregion

        #region Event Handlers
        private void LifeGrid_Paint(object sender, PaintEventArgs e)
        {
            float cellWidth = (float)Width / _cols;
            float cellHeight = (float)Height / _rows;
            float line = 0;
            if (_gridLinesVisible) { line = _gridLineThickness; }

            Graphics painter = e.Graphics;
            SolidBrush aliveBrush = new SolidBrush(_cellColorAlive);
            SolidBrush deadBrush = new SolidBrush(_cellColorDead);
            // Clear the control
            painter.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 0, Width, Height));

            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _cols; x++)
                {
                    if (_gridStates[x + y * _cols])
                    {
                        painter.FillRectangle(aliveBrush, x * cellWidth, y * cellHeight,
                          cellWidth - line, cellHeight - line);
                    }
                    else
                    {
                        painter.FillRectangle(deadBrush, x * cellWidth, y * cellHeight,
                              cellWidth - line, cellHeight - line);
                    }
                }
            }
        }
        #endregion
    }
}