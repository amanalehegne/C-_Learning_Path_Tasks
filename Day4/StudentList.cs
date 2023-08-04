using System.Xml;
using System;
using Newtonsoft.Json;

namespace StudentManagement;

class StudentList<T>
{
    private List<T> Students = new List<T>();

    public void AddStudent(T student)
    {
        Students.Add(student);
    }

    public void SearchStudent()
    {
        Console.WriteLine("Enter Name or ID:");
        string input = Console.ReadLine();

        // Use LINQ to check if the student in the list matches either the name ot the roll numeber (ID)
        var searchResult = from student in Students
                           where
                           (student is Student sName && sName.Name.ToString() == input) ||
                           (student is Student s && s.RollNumber.ToString() == input)
                           select student;

        if (searchResult.Count() == 0)
        {
            Console.WriteLine(":( Nothing Found");
        } else
        {
            Console.WriteLine("Search Result");
            foreach (T student in searchResult)
            {
                // Type Check The student generic object and if its of Student class then we assign it a variable and the property
                string Name = (student is Student sName) ? sName.Name.ToString() : "";
                string Age = (student is Student sAge) ? sAge.Age.ToString() : "";
                string RollNumber = (student is Student s) ? s.RollNumber.ToString() : "";
                string Grade = (student is Student sGrade) ? sGrade.Grade.ToString() : "";

                Console.WriteLine($"Name: {Name} | Age: {Age} | Rollnumber: {RollNumber} | Grade: {Grade}");
            }
        }

    }

    public void ListStudents()
    {
        if (Students.Count() == 0)
        {
            Console.WriteLine("There Are No Students");
        }
        else
        {
            Console.WriteLine("Students List");
            foreach (T student in Students)
            {
                string Name = (student is Student sName) ? sName.Name.ToString() : "";
                string Age = (student is Student sAge) ? sAge.Age.ToString() : "";
                string RollNumber = (student is Student s) ? s.RollNumber.ToString() : "";
                string Grade = (student is Student sGrade) ? sGrade.Grade.ToString() : "";

                Console.WriteLine($"Name: {Name} | Age: {Age} | Rollnumber: {RollNumber} | Grade: {Grade}");
            }
        }

    }


    public void Serialize(string fileName)
    {
        try
        {
            var JsonFile = JsonConvert.SerializeObject(Students, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(fileName, JsonFile);
            Console.WriteLine("Object Serialized Successfuly :)");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Can serialization: " + ex.Message);
        }
    }

    public void DeSerialize(string fileName)
    {
        try
        {
            var JsonFile = File.ReadAllText(fileName);
            Students = JsonConvert.DeserializeObject<List<T>>(JsonFile);
            Console.WriteLine("Object Deserialized Successfully :)");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Can't deserialization: " + ex.Message);
        }
    }

}

