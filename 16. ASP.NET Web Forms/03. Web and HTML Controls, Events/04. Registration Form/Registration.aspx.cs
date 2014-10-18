namespace RegistrationForm
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Registration : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubmitForm(object sender, EventArgs e)
        {
            if (this.IsGroupValid("student"))
            {
                var ctrl = this.LoadControl(
                    "SubmitedStudent.ascx",
                    new object[]
                        {
                            this.firstName.Text, 
                            this.lastName.Text, 
                            this.facultyNumber.Text, 
                            this.university.SelectedValue, 
                            this.specialty.SelectedValue
                    });

                this.studentHolder.Controls.Add(ctrl);
            }
        }

        protected bool IsGroupValid(string validationGroup)
        {
            foreach (BaseValidator validator in Page.Validators)
            {
                if (validator.ValidationGroup == validationGroup)
                {
                    bool isValid = validator.IsValid;
                    if (isValid)
                    {
                        validator.Validate();
                        isValid = validator.IsValid;
                        validator.IsValid = true;
                    }

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private UserControl LoadControl(string userControlPath, params object[] constructorParameters)
        {
            var ctl = Page.LoadControl(userControlPath) as UserControl;

            ConstructorInfo constructor =
                ctl.GetType()
                    .BaseType.GetConstructor(constructorParameters.Select(constParam => constParam.GetType()).ToArray());

            if (constructor == null)
            {
                throw new MemberAccessException(
                    "The requested constructor was not found on : " + ctl.GetType().BaseType);
            }

            constructor.Invoke(ctl, constructorParameters);

            return ctl;
        }
    }
}