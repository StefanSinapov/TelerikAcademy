using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
	public interface ICourseFactory
	{
		ITeacher CreateTeacher(string name);
		ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
		IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
	}
}
