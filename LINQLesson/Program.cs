using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using EducationLibrary;

namespace LINQLesson {
	class Program {

		void RunExamplesFromChapter21() {
			var students = StudentCollection.Select();
			var AverageGPA = students.Where(s => s.SAT > 1000).Average(s => s.GPA);
			Debug.WriteLine($"Average GPA is {AverageGPA}");
			var StudentsCount = students.Where(s => s.SAT > 1000).Count();
			Debug.WriteLine($"Count is {StudentsCount}");
			StudentsCount = students.Where(s => s.GPA >= 2.5 && s.GPA <= 3.5).Count();
			Debug.WriteLine($"Count students with GPA 2.5 < x < 3.5 is {StudentsCount}");
		}
		void RunStudentsWithMajorIdsLessThanFour() {
			var students = StudentCollection.Select()
				.Where(s => s.MajorId <= 4 && s.MajorId != -1)
				.OrderByDescending(s => s.LastName);

			var s10 = students.ToList().Find(s => s.Id == 10);
			Debug.WriteLine($"{s10.FirstName} {s10.LastName} {s10.MajorId}");

			//foreach (var s in students) {
			//	Debug.WriteLine($"{s.FirstName} {s.LastName} {s.MajorId}");
			//}
		}
		void RunJoiningMajorToStudent() {

			List<Major> majors = new List<Major> {
				new Major() { Id = 1, Description = "Audiology" },
				new Major() { Id = 2, Description = "Biology" },
				new Major() { Id = 3, Description = "Linguists" },
				new Major() { Id = 4, Description = "CS" },
				new Major() { Id = 5, Description = "ME" },
				new Major() { Id = 6, Description = "IPS" }
			};

			var students = StudentCollection.Select();

			var studentsAndMajors = from s in students
									join m in majors
									on s.MajorId equals m.Id
									select new { s.FirstName, s.LastName, m.Description };

			foreach(var s in studentsAndMajors) {
				Debug.WriteLine($"{s.FirstName} {s.LastName} majoring in {s.Description}");
			}
		}
		void Run() {
			var students = StudentCollection.Select();

			// to get students with GPA >= 3.5 and SAT > 1400 in GPA descending sequence WITHOUT LINQ
			StudentCollection DeansListStudents = new StudentCollection();
			foreach(var s in students) {
				if(s.GPA >= 3.5 && s.SAT > 1400) {
					DeansListStudents.Add(s);
				}
			}
			// with LINQ
			var TopStudents = students
				.Where(stud => stud.GPA >= 3.5 && stud.SAT > 1400)
				.OrderByDescending(s => s.GPA);

			foreach(var student in TopStudents) {
				Debug.WriteLine($"{student.FirstName} {student.LastName} GPA is {student.GPA} SAT is {student.SAT}");
			}
		}

		static void Main(string[] args) {
			new Program().RunExamplesFromChapter21();
		}
	}
}
