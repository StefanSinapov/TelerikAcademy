using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Services.Repositories
{
    public class XmlStudentsRepository : IStudentsRepository
    {
        private string xmlFilePath;
        private XElement documentRoot;        

        public XmlStudentsRepository(string xmlFilePath)
        {
            this.xmlFilePath = xmlFilePath;
        }

        public XElement DocumentRoot
        {
            get
            {
                if (this.documentRoot == null)
                {
                    this.documentRoot = XDocument.Load(this.xmlFilePath).Root;
                }
                return this.documentRoot;
            }
        }

        public Student GetById(int id)
        {
            var theStudentElement = GetStudentElementById(id);
            var theStudent = this.ParseXmlElementToStudent(theStudentElement);
            return theStudent;
        }
  
        public IEnumerable<Student> GetAll()
        {
            var studentElements = this.DocumentRoot.Elements("student");
            var students =
                          from studentElement in studentElements
                          select this.ParseXmlElementToStudent(studentElement);
            return students;
        }
  
        private Student ParseXmlElementToStudent(XElement element)
        {
            var student = new Student()
            {
                Id = int.Parse(element.Attribute("id").Value),
                FirstName = element.Attribute("fname").Value,
                LastName = element.Attribute("lname").Value
            };
            return student;
        }

        public Student Add(Student item)
        {
            var id = int.Parse(this.DocumentRoot.Attribute("last-id").Value) + 1;
            this.DocumentRoot.SetAttributeValue("last-id", id);
            var newStudentElement = new XElement("student",
                new XAttribute("id", id),
                new XAttribute("fname", item.FirstName),
                new XAttribute("lname", item.LastName));
            this.DocumentRoot.Add(newStudentElement);
            this.SaveChanges();

            return new Student()
            {
                Id = id,
                FirstName = item.FirstName,
                LastName = item.LastName
            };
        }
        
        public void Delete(Student item)
        {
            var theStudentElement = this.GetStudentElementById(item.Id);
            theStudentElement.Remove();
            this.SaveChanges();
        }

        public void Update(Student item)
        {
            var theStudentElement = this.GetStudentElementById(item.Id);
            theStudentElement.SetAttributeValue("fname", item.FirstName);
            theStudentElement.SetAttributeValue("lname", item.LastName);
            this.SaveChanges();
        }

        private XElement GetStudentElementById(int id)
        {
            var studentElements = this.DocumentRoot.Elements("student");
            var idStr = id.ToString();
            var theStudentElement = studentElements.FirstOrDefault(st => st.Attribute("id").Value == idStr);
            if (theStudentElement == null)
            {
                throw new ArgumentNullException("No such student");
            }
            return theStudentElement;
        }

        private void SaveChanges()
        {
            this.DocumentRoot.Document.Save(this.xmlFilePath);
        }
    }
}