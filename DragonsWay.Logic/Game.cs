using System.Text;

namespace DragonsWay.Logic
{
    public class Game
    {
        private char[,] _cave;
        private bool _win;

        public Game(int n, string path)
        {
            N = n;
            M = n * 2;
            CreateCave(n);
            CreatePath(path);
        }

        public int N { get; }
        public int M { get; }

        private void CreateCave(int n)
        {
            _cave = new char[n, n * 2];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n * 2; j++)
                {
                    if (i == 0 || i == n - 1 || j == 0 || j == n * 2 - 1)
                    {
                        _cave[i, j] = '█';
                    }
                    else
                    {
                        _cave[i, j] = ' ';
                    }
                }
            }
        }

        private void CreatePath(string path)
        {
            int x = 1;
            int y = 0;

            foreach (char direction in path)
            {
                var arrow = "";
                if (direction == '↓')
                {
                    x++;
                    arrow = "↓";
                }
                else if (direction == '→')
                {
                    y++;
                    arrow = "→";
                }

                if (x < 0 || x >= _cave.GetLength(0) || y < 0 || y >= _cave.GetLength(1) || _cave[x, y] == '█' && x != 1 && y != 0)
                {
                    _win = false;
                    break;
                }

                if (arrow == "↓")
                {
                    _cave[x, y] = '↓';
                }
                else if (arrow == "→")
                {
                    _cave[x, y] = '→';
                }

                if (x == _cave.GetLength(0) - 2 && y == _cave.GetLength(1) - 2)
                {
                    _win = true;
                    break;
                }
            }
        }

        public bool Win => _win;

        public override string ToString()
        {
            var output = string.Empty;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    output += $"{_cave[i, j]}";
                }
                output += "\n";
            }
            return output;
        }
    }
}
