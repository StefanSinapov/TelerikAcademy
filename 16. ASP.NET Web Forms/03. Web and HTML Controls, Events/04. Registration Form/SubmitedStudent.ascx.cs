namespace RegistrationForm
{
    using System;
    using System.Web.UI;

    public partial class SubmitedStudent : UserControl
    {
         public SubmitedStudent()
        {
        }

         public SubmitedStudent(string firstName, string lastName, string facultyNumber, 
             string university, string specialty)
        {
            this.firstName.InnerHtml = firstName;
            this.lastName.InnerHtml = lastName;
            this.facultyNumber.InnerHtml = facultyNumber;
            this.university.InnerHtml = university;
            this.specialty.InnerHtml = specialty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}