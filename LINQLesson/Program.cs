using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationLibrary;

namespace LINQLesson {
	class Program {
		static void Main(string[] args) {
			StudentCollection students = StudentCollection.Select();
			var someStudentData = students.Select(c => 
				new {
					FullName = $"{c.LastName}, {c.FirstName}",
					GPA = c.GPA,
					SAT = c.SAT
				}
			);
			foreach(var s in someStudentData) {
				System.Diagnostics.Debug.WriteLine($"{s.FullName}, {s.GPA}, {s.SAT}");
			}
			System.Diagnostics.Debug.WriteLine("***************");
			var somestudents = students.Where(c => c.Email == "a@b.c");
			foreach (var s in somestudents) {
				System.Diagnostics.Debug.WriteLine($"{s.FirstName + " " + s.LastName}, {s.GPA}, {s.SAT}");
			}
		}
	}
}
