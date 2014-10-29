namespace Articles.Web.Controls.LikeControl
{
    using System;
    using System.Globalization;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class LikeEventArgs : EventArgs
    {
        public LikeEventArgs(object dataID, bool likeValue)
        {
            this.DataId = dataID;
            this.LikeValue = likeValue;
        }

        public object DataId { get; set; }

        public bool LikeValue { get; set; }
    }

    public partial class LikeControl : UserControl
    {
        public int LikesValue { get; set; }

        public int DataId { get; set; }

        public bool? UserVote { get; set; }

        public delegate void LikeEventHandler(object sender, LikeEventArgs e);

        public event LikeEventHandler Like;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.LableLikesCount.Text = this.LikesValue.ToString(CultureInfo.InvariantCulture);

            if (this.UserVote.HasValue)
            {
                if (this.UserVote.Value)
                {
                    this.ButtonLike.Visible = false;
                    this.ButtonHate.Visible = true;
                }
                else
                {
                    this.ButtonLike.Visible = true;
                    this.ButtonHate.Visible = false;
                }
            }
        }

        protected void ButtonLike_Command(object sender, CommandEventArgs e)
        {
            bool likeValue = e.CommandName == "Like" ? true : false;
            this.Like(this, new LikeEventArgs(e.CommandArgument, likeValue));
        }
    }
}