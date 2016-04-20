using System;
using System.IO;
using System.Text;

namespace kiswa.Games.Life.DataLayer
{
    /// <summary>
    /// Provides access to files for loading
    /// Game of Life patterns.
    /// </summary>
    public static class FileLoad
    {
        #region Properties
        /// <summary>
        /// Gets whether a file is loaded.
        /// </summary>
        public static bool IsFileLoaded
        {
            get { return _isFileLoaded; }
        }
        /// <summary>
        /// Gets the description of the
        /// last loaded Life pattern.
        /// </summary>
        public static string PatternDescription
        {
            get { return _patternDescription; }
        }
        #endregion

        #region Fields
        private static bool _isFileLoaded;
        private static string _patternDescription;

        private static string[] _gameFileData;
        private static int _centerColumn;
        private static int _centerRow;
        #endregion

        #region Public Methods
        /// <summary>
        /// Opens the specified file and loads the pattern
        /// into the provided <see cref="LifeGame">LifeGame</see>.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="game"></param>
        public static void LoadLifeFile(string filePath, LifeGame game)
        {
            _centerColumn = game.Columns / 2;
            _centerRow = game.Rows / 2;

            using (StreamReader sr = new StreamReader(filePath))
            {
                StringBuilder sb = new StringBuilder();

                while (!sr.EndOfStream)
                {
                    sb.AppendLine(sr.ReadLine());
                }

                _gameFileData = sb.ToString().Replace("\r","").Split('\n');
            }

            switch (_gameFileData[0].Trim())
            {
                case "#Life 1.05":
                    loadFileLife105(game);
                    _isFileLoaded = true;
                    break;
                default:
                    _isFileLoaded = false;
                    throw new InvalidDataException("Unrecognized file format.");
            }
        }
        #endregion

        #region Private Methods
        private static void loadFileLife105(LifeGame game)
        {
            string ruleset = String.Empty;
            StringBuilder descriptionLines = new StringBuilder();
            int gridX, gridXStart;
            int gridY;

            game.ClearGrid();

            for (int i = 1; i < _gameFileData.Length; i++)
            {
                if (_gameFileData[i].Trim().StartsWith("#D") || _gameFileData[i].Trim().StartsWith("#C"))
                {
                    descriptionLines.AppendLine(_gameFileData[i].Substring(2).Trim());
                }
                if (_gameFileData[i].Trim().StartsWith("#R"))
                {
                    ruleset = _gameFileData[i].Substring(2).Trim();
                }
                if (_gameFileData[i].Trim().StartsWith("#N"))
                {
                    ruleset = "23/3";
                }
                if (_gameFileData[i].Trim().StartsWith("#P"))
                {
                    string[] gridPositions = _gameFileData[i].Split(' ');
                    gridXStart = _centerColumn + Int32.Parse(gridPositions[1]);
                    gridY = _centerRow + Int32.Parse(gridPositions[2]);

                    i++;
                    while ((i < _gameFileData.Length) && (!_gameFileData[i].Trim().StartsWith("#P")))
                    {
                        char[] lineData = _gameFileData[i].ToCharArray();
                        gridX = gridXStart;
                        foreach (char onOff in lineData)
                        {
                            if (onOff == '*')
                            { game.ToggleCellState(gridX, gridY); }
                            gridX++;
                        }
                        gridY++;
                        i++;
                    }
                    // Back up one if we've hit another pattern before EOF
                    if ((i < _gameFileData.Length) && (_gameFileData[i].Trim().StartsWith("#P")))
                    { i--; }
                }
            }
            _patternDescription = descriptionLines.ToString();
            game.ChangeRules(ruleset);  // If ruleset is invalid, ChangeRules will default to "23/3"
        }
        #endregion
    }
}