namespace CrowdChat.Web
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI;

    using CrowdChat.Common;
    using CrowdChat.Data;
    using CrowdChat.Models;

    using Microsoft.AspNet.Identity;

    public partial class ChatBox : Page
    {
        private readonly CrowdChatDbContext context;

        public ChatBox()
        {
            this.context = new CrowdChatDbContext();
        }

        public IQueryable<Message> Select()
        {
            return this.context.Messages.OrderBy(m => m.DateCreated).Include("Author");
        }

        public void Insert()
        {
            var message = new Message();
            var userId = this.User.Identity.GetUserId();

            message.DateCreated = DateTime.Now;
            message.AuthorId = userId;

            this.TryUpdateModel(message);

            if (this.ModelState.IsValid)
            {
                this.context.Messages.Add(message);
                this.context.SaveChanges();
            }

            this.ListViewMessages.DataBind();
        }

        public void Delete(Guid id)
        {
            var message = this.context.Messages.First(m => m.Id == id);

            this.context.Messages.Remove(message);
            this.context.SaveChanges();
        }

        public void Update(Guid id)
        {
            var message = this.context.Messages.First(m => m.Id == id);

            if (message == null)
            {
                // The item wasn't found
                this.ModelState.AddModelError(string.Empty, string.Format("Item with id {0} was not found", id));
                return;
            }

            this.TryUpdateModel(message);
            if (this.ModelState.IsValid)
            {
                this.context.SaveChanges();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                this.Page.Title = "User admin";
            }
        }

        /*   protected void ButtonSend_OnClick(object sender, EventArgs e)
           {
               if (!this.User.Identity.IsAuthenticated)
               {
                   Response.Redirect("~/Account/Register.aspx");
                   Response.End();
               }

               var userId = this.User.Identity.GetUserId();
               var text = this.TextBoxContent.Text;

               var message = new Message
               {
                   Content = text,
                   AuthorId = userId,
                   DateCreated = DateTime.Now
               };

               this.context.Messages.Add(message);
               this.context.SaveChanges();

               this.TextBoxContent.Text = string.Empty;
           }*/
    }
}