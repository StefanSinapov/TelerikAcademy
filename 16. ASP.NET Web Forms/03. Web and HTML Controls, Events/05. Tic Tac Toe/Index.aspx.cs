namespace TicTacToe
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public partial class Index : Page
    {
        private string[][] field;

        private string setSign;

        private string computerSign;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.ViewState["this.field"] == null)
            {
                this.field = new string[3][];
                this.field[0] = new string[3];
                this.field[1] = new string[3];
                this.field[2] = new string[3];

                ViewState.Add("this.field", this.field);
                this.ViewState.Add("winner", string.Empty);
                ViewState.Add("turns", 1);
            }
            else
            {
                this.computerSign = "O";
                this.setSign = "X";
                this.field = (string[][])ViewState["this.field"];
            }
        }

        protected void TopLeftClick(object sender, EventArgs e)
        {
            if (this.IsMoveValid(0, 0))
            {
                this.ProcessMove(this.setSign, this.top_left, 0, 0);
            }
        }

        protected void TopCenterClick(object sender, EventArgs e)
        {
            if (this.IsMoveValid(0, 1))
            {
                this.ProcessMove(this.setSign, this.top_center, 0, 1);
            }
        }

        protected void TopRightClick(object sender, EventArgs e)
        {
            if (this.IsMoveValid(0, 2))
            {
                this.ProcessMove(this.setSign, this.top_right, 0, 2);
            }
        }

        protected void MiddleLeftClick(object sender, EventArgs e)
        {
            if (this.IsMoveValid(1, 0))
            {
                this.ProcessMove(this.setSign, this.middle_left, 1, 0);
            }
        }

        protected void MiddleCenterClick(object sender, EventArgs e)
        {
            if (this.IsMoveValid(1, 1))
            {
                this.ProcessMove(this.setSign, this.middle_center, 1, 1);
            }
        }

        protected void MiddleRightClick(object sender, EventArgs e)
        {
            if (this.IsMoveValid(1, 2))
            {
                this.ProcessMove(this.setSign, this.middle_right, 1, 2);
            }
        }

        protected void BottomLeftClick(object sender, EventArgs e)
        {
            if (this.IsMoveValid(2, 0))
            {
                this.ProcessMove(this.setSign, this.bottom_left, 2, 0);
            }
        }

        protected void BottomCenterClick(object sender, EventArgs e)
        {
            if (this.IsMoveValid(2, 1))
            {
                this.ProcessMove(this.setSign, this.bottom_center, 2, 1);
            }
        }

        protected void BottomRightClick(object sender, EventArgs e)
        {
            if (this.IsMoveValid(2, 2))
            {
                this.ProcessMove(this.setSign, this.bottom_right, 2, 2);
            }
        }

        private void ProcessGame()
        {
            if (this.CheckForWinner())
            {
                this.PrintScore();
            }
            else
            {
                this.ComputerMove();
                this.PrintComputerMoves();
                if (this.CheckForWinner())
                {
                    this.PrintScore();
                }
            }
        }

        private void PrintScore()
        {
            this.score.InnerHtml = "Winner is " + this.ViewState["winner"] + "<br/>In " + this.ViewState["turns"] + " turns";
            this.ViewState["this.field"] = null;
        }

        private void PrintComputerMoves()
        {
            if (this.field[0][0] == this.computerSign)
            {
                this.top_left.InnerHtml = this.computerSign;
            }

            if (this.field[0][1] == this.computerSign)
            {
                this.top_center.InnerHtml = this.computerSign;
            }

            if (this.field[0][2] == this.computerSign)
            {
                this.top_right.InnerHtml = this.computerSign;
            }

            if (this.field[1][0] == this.computerSign)
            {
                this.middle_left.InnerHtml = this.computerSign;
            }

            if (this.field[1][1] == this.computerSign)
            {
                this.middle_center.InnerHtml = this.computerSign;
            }

            if (this.field[1][2] == this.computerSign)
            {
                this.middle_right.InnerHtml = this.computerSign;
            }

            if (this.field[2][0] == this.computerSign)
            {
                this.bottom_left.InnerHtml = this.computerSign;
            }

            if (this.field[2][1] == this.computerSign)
            {
                this.bottom_center.InnerHtml = this.computerSign;
            }

            if (this.field[2][2] == this.computerSign)
            {
                this.bottom_right.InnerHtml = this.computerSign;
            }
        }

        private void ComputerMove()
        {
            var rng = new Random();

            while (true)
            {
                var row = rng.Next(0, 3);
                var col = rng.Next(0, 3);
                if (this.field[row][col] == null)
                {
                    this.field[row][col] = this.computerSign;
                    break;
                }
            }
        }

        private void ProcessMove(string playerSign, HtmlButton btn, int row, int col)
        {
            btn.InnerHtml = playerSign;
            this.field[row][col] = playerSign;
            this.ProcessGame();
            var turns = (int)ViewState["turns"];
            this.ViewState["turns"] = turns + 1;
        }

        private bool IsMoveValid(int row, int col)
        {
            if (this.field[row][col] == null)
            {
                return true;
            }

            return false;
        }

        private bool CheckForWinner()
        {
            // rows
            for (int i = 0; i < 3; i++)
            {
                var count = 1;
                string lastP = this.field[i][0];
                for (int j = 1; j < 3; j++)
                {
                    if (this.field[i][j] == lastP && lastP != null)
                    {
                        count++;
                        lastP = this.field[i][j];
                    }
                    else
                    {
                        break;
                    }
                }

                if (count == 3)
                {
                    this.ViewState["winner"] = lastP;
                    return true;
                }
            }

            // cols
            for (int i = 0; i < 3; i++)
            {
                var count = 1;
                string lastP = this.field[0][i];
                for (int j = 1; j < 3; j++)
                {
                    if (this.field[j][i] == lastP && lastP != null)
                    {
                        count++;
                        lastP = this.field[j][i];
                    }
                    else
                    {
                        break;
                    }
                }

                if (count == 3)
                {
                    this.ViewState["winner"] = lastP;
                    return true;
                }
            }

            // diagonals
            if (this.field[0][0] == this.field[1][1] && this.field[1][1] == this.field[2][2] && this.field[1][1] != null)
            {
                this.ViewState["winner"] = this.field[0][0];
                return true;
            }

            if (this.field[0][2] == this.field[1][1] && this.field[1][1] == this.field[2][0] && this.field[1][1] != null)
            {
                this.ViewState["winner"] = this.field[1][1];
                return true;
            }

            return false;
        }
    }
}