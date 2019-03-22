using System;
using System.Collections.Generic;

public class AverageStudentGrades
{
    public static void Main()
    {
        var studentsWithThereGrades = new Dictionary<string, List<double>>();

        var givenStudentsWithThereGrades = Convert.ToInt32(Console.ReadLine());
        for (int count = 0; count < givenStudentsWithThereGrades; count++)
        {
            var nextStudentWithHisGrade = Console.ReadLine().Split(' ');
            var studentName = nextStudentWithHisGrade[0];
            var studentGrade = Convert.ToDouble(nextStudentWithHisGrade[1]); 

            if (!studentsWithThereGrades.ContainsKey(studentName))
            {
                studentsWithThereGrades[studentName] = new List<double>();
            }
            studentsWithThereGrades[studentName].Add(studentGrade);
        }

        foreach (var student in studentsWithThereGrades)
        {
            var sum = 0.0;
            Console.Write($"{student.Key} ->");
            foreach (var grade in student.Value)
            {
                Console.Write($" {grade:F2}");
                sum += grade;
            }
            Console.WriteLine($" (avg: {sum / student.Value.Count:F2})");
        }
    }
}
