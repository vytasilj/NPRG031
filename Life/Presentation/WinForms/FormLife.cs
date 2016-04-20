using System;
using System.Collections.Generic;
using System.Windows.Forms;
using kiswa.Games.Life.DataLayer;

namespace kiswa.Games.Life.WinFormsApp
{
    /// <summary>
    /// Represents the type of zoom requested.
    /// </summary>
    enum ZoomType { In, Out }

    /// <summary>
    /// Form to display a GoL simulation
    /// </summary>
    public partial class FormLife : Form
    {
        #region Fields
        private LifeGame _lifeGame;
        private Timer _timer;
        private double _probability;
        private int _gridSize;
        private int _stepNumber;
        private List<string> _gameRules;

        private int _zoomStartX;
        private int _zoomStartY;
        private int _zoomMax;
        private double _zoomRate;
        private int _zoomCount;

        private DateTime _startTime;
        private DateTime _stopTime;
        #endregion

        #region Public Constructor
        /// <summary>
        /// Default ctor - Instantiates the form.
        /// </summary>
        public FormLife()
        {
            InitializeComponent();

            #region Field Initialization
            _probability = 0.25;
            _gridSize = 250;
            _stepNumber = 0;

            _zoomStartX = pnlScroller.Width;
            _zoomStartY = pnlScroller.Height;
            _zoomMax = 5;
            _zoomRate = 1.5;
            _zoomCount = 0;
            #endregion

            _lifeGame = new LifeGame(_gridSize);
            _timer = new Timer();
            _gameRules = new List<string>();

            lifeGrid.Columns = _gridSize;
            lifeGrid.Rows = _gridSize;
            lifeGrid.LinesVisible = mnuiOptionsShowGrid.Checked;

            _timer.Enabled = false;
            _timer.Interval = 1;

            addRulesToComboBox();

            #region Event Handler Creation
            _timer.Tick += new EventHandler(_timer_Tick);

            cmbRules.TextChanged += new EventHandler(cmbRules_TextChanged);

            lifeGrid.MouseDown += new MouseEventHandler(lifeGrid_MouseDown);

            btnStart.Click += new EventHandler(btnStart_Click);
            btnStop.Click += new EventHandler(btnStop_Click);
            btnStep.Click += new EventHandler(btnStep_Click);

            btnReset.Click += new EventHandler(btnReset_Click);
            btnClear.Click += new EventHandler(btnClear_Click);
            btnRandomize.Click += new EventHandler(btnRandomize_Click);

            btnZoomIn.Click += new EventHandler(btnZoomIn_Click);
            btnZoomOut.Click += new EventHandler(btnZoomOut_Click);
            #endregion
            //runTest(_gridSize);
        }
        #endregion

        #region Private Methods
        private void addRulesToComboBox()
        {
            // Rule Format: Survive number(s) "/" Birth number(s) " "
            // after the [space] anything else (e.g. description)
            // 9 is not a valid number!
            _gameRules.Add("23/3          - Conway's Life");
            _gameRules.Add("125/36        - 2x2");
            _gameRules.Add("34/34         - 34 Life");
            _gameRules.Add("1358/357      - Amoeba");
            _gameRules.Add("35678/4678    - Anneal");
            _gameRules.Add("4567/345      - Assimilation");
            _gameRules.Add("235678/378    - Coagulations");
            _gameRules.Add("45678/3       - Coral");
            _gameRules.Add("34678/3678    - Day & Night");
            _gameRules.Add("5678/35678    - Diamoeba");
            _gameRules.Add("012345678/3   - Flakes");
            _gameRules.Add("1/1           - Gnarl");
            _gameRules.Add("23/36         - HighLife");
            _gameRules.Add("34678/0123478 - Inverse Life");
            _gameRules.Add("5/345         - Long Life");
            _gameRules.Add("12345/3       - Maze");
            _gameRules.Add("1234/3        - Mazectric");
            _gameRules.Add("245/368       - Move");
            _gameRules.Add("238/357       - Pseudo Life");
            _gameRules.Add("1357/1357     - Replicator");
            _gameRules.Add("/2            - Seeds");
            _gameRules.Add("/234          - Serviettes");
            _gameRules.Add("235678/3678   - Stains");
            _gameRules.Add("2345/45678    - Walled cities");
            
            foreach (string rule in _gameRules)
            {
                cmbRules.Items.Add(rule);
            }
            cmbRules.SelectedIndex = 0;
        }

        private void zoomView(ZoomType zoomType)
        {
            if (zoomType == ZoomType.In)
            {
                if ((lifeGrid.Width < (_zoomMax * _zoomStartX)) &&
                    (lifeGrid.Height < (_zoomMax * _zoomStartY)))
                {
                    lifeGrid.Width = Convert.ToInt32(lifeGrid.Width * _zoomRate);
                    lifeGrid.Height = Convert.ToInt32(lifeGrid.Height * _zoomRate);
                    _zoomCount += 1;
                }
            }
            else
            {
                if ((lifeGrid.Width > _zoomStartX) ||
                    (lifeGrid.Height > _zoomStartY))
                {
                    lifeGrid.Width = Convert.ToInt32(lifeGrid.Width / _zoomRate);
                    lifeGrid.Height = Convert.ToInt32(lifeGrid.Height / _zoomRate);
                    _zoomCount -= 1;
                }
            }
            updateFormVisuals();
        }

        private void updateFormVisuals()
        {
            lblStepNumber.Text = "Gen: ";
            if (_stepNumber > 0)
            { lblStepNumber.Text += _stepNumber.ToString(); }

            lblPopulation.Text = "Pop: ";
            if (_lifeGame.LiveCellCount > 0)
            { lblPopulation.Text += _lifeGame.LiveCellCount; }

            lblZoomCount.Text = (_zoomCount + 1).ToString();

            lifeGrid.UpdateGrid(_lifeGame.GameGrid);
        }

        private void aboutLatestPattern()
        {
            MessageBox.Show(FileLoad.PatternDescription,
                "About Latest Pattern",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
        }
        #endregion

        #region Event Handlers

        #region Timer Event Handlers
        void _timer_Tick(object sender, EventArgs e)
        {
            _lifeGame.Step();
            _stepNumber += 1;

            if (_stepNumber % 6 == 0)
            { updateFormVisuals(); }

            //if (_stepNumber == 1000)
            //{
            //    _stopTime = DateTime.Now;
            //    MessageBox.Show("1000 generations with visuals took " + (_stopTime - _startTime));
            //}
        }
        #endregion

        #region ComboBox Event Handlers
        void cmbRules_TextChanged(object sender, EventArgs e)
        {
            string[] ruleName = cmbRules.Text.Split(' ');

            _lifeGame.ChangeRules(ruleName[0]);
        }
        #endregion

        #region LifeGrid Event Handlers
        void lifeGrid_MouseDown(object sender, MouseEventArgs e)
        {
            int y = (int)(((float)e.Y) * _lifeGame.Rows / lifeGrid.Height);
            int x = (int)(((float)e.X) * _lifeGame.Columns / lifeGrid.Width);

            _lifeGame.ToggleCellState(x, y);
            lifeGrid.UpdateGrid(_lifeGame.GameGrid);
        }
        #endregion

        #region Button Event Handlers
        void btnStart_Click(object sender, EventArgs e)
        {
            _lifeGame.SetStart();
            _timer.Start();
            _startTime = DateTime.Now;
        }

        void btnStop_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            updateFormVisuals();
        }

        void btnStep_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            _lifeGame.Step();
            _stepNumber += 1;

            updateFormVisuals();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            _lifeGame.ResetGrid();
            _stepNumber = 0;

            updateFormVisuals();
        }

        void btnClear_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            _lifeGame.ClearGrid();
            _stepNumber = 0;

            updateFormVisuals();
        }

        void btnRandomize_Click(object sender, EventArgs e)
        {
            _lifeGame.Randomize(_probability);
            _stepNumber = 0;

            updateFormVisuals();
        }

        void btnZoomIn_Click(object sender, EventArgs e)
        {
            zoomView(ZoomType.In);
        }

        void btnZoomOut_Click(object sender, EventArgs e)
        {
            zoomView(ZoomType.Out);
        }
        #endregion

        #region Menu Item Event Handlers
        #region File
        private void mnuiFileLoadPattern_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Life File (*.lif;*.life;*.rle)|*.lif;*.life;*.rle";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileLoad.LoadLifeFile(openFile.FileName, _lifeGame);
                    _stepNumber = 0;
                    updateFormVisuals();
                    if (FileLoad.IsFileLoaded)
                    {
                        // Update the rules combobox to select the loaded file's ruleset
                        int index = _gameRules.FindIndex(delegate(string s) { return s.StartsWith(_lifeGame.Rules); });
                        cmbRules.SelectedIndex = index;

                        mnuiHelpAboutPattern.Enabled = true;
                        aboutLatestPattern();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "File Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mnuiFileSavePattern_Click(object sender, EventArgs e)
        {
            // TODO...
        }

        private void mnuiFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #region Options
        private void mnuiOptionsShowGrid_Click(object sender, EventArgs e)
        {
            mnuiOptionsShowGrid.Checked = !(mnuiOptionsShowGrid.Checked);

            lifeGrid.LinesVisible = mnuiOptionsShowGrid.Checked;
        }

        private void mnuiOptionsLiveCellColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.Color = lifeGrid.CellColorAlive;

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                lifeGrid.CellColorAlive = colorPicker.Color;
            }
        }

        private void mnuiOptionsDeadCellColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.Color = lifeGrid.CellColorDead;

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                lifeGrid.CellColorDead = colorPicker.Color;
            }
        }
        #endregion
        #region Help
        private void mnuiHelpAboutPattern_Click(object sender, EventArgs e)
        {
            aboutLatestPattern();
        }

        private void mnuiHelpAboutGoL_Click(object sender, EventArgs e)
        {
            FormAbout about = new FormAbout();
            about.ShowDialog();
        }
        #endregion
        #endregion

        #endregion

        private void runTest(int gridSize)
        {
            LifeGame lifeSim = new LifeGame(gridSize);
            lifeSim.Randomize(.25);

            int startCount = lifeSim.LiveCellCount;

            _startTime = DateTime.Now;
            for (int i = 0; i < 1000; i++)
            {
                lifeSim.Step();
            }
            _stopTime = DateTime.Now;

            MessageBox.Show("Initial population of " + startCount +
                ".\n\n1000 random generations took " + (_stopTime - _startTime));
        }

    }
}