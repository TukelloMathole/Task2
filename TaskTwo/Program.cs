using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DatasetProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            string programDirectory = GetProgramDirectory();

            string inputFileName = Path.Combine(programDirectory, "Employee.csv");

            if (!File.Exists(inputFileName))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            List<Employee> dataset = ReadDataFromCSV(inputFileName);

            List<Employee> sortedData = SortDataByJoiningYear(dataset);

            foreach (var employee in sortedData)
            {
                Console.WriteLine(employee);
            }
        }

        static List<Employee> ReadDataFromCSV(string filePath)
        {
            List<Employee> dataset = new List<Employee>();


            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (values.Length != 9)
                    {
                        continue;
                    }

                    Employee employee = new Employee
                    {
                        Education = values[0].Trim(),
                        JoiningYear = ParseInt(values[1].Trim()),
                        City = values[2].Trim(),
                        PaymentTier = ParseInt(values[3].Trim()),
                        Age = ParseInt(values[4].Trim()),
                        Gender = values[5].Trim(),
                        EverBenched = ParseBool(values[6].Trim()),
                        ExperienceInCurrentDomain = ParseInt(values[7].Trim()),
                        LeaveOrNot = ParseBool(values[8].Trim())
                    };

                    dataset.Add(employee);
                }
            }

            return dataset;
        }


        static int ParseInt(string value)
        {
            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            return 0; 
        }

        static bool ParseBool(string value)
        {
            bool result;
            if (bool.TryParse(value, out result))
            {
                return result;
            }
            return false;
        }

        static List<Employee> SortDataByJoiningYear(List<Employee> data)
        {
            return data.OrderBy(e => e.JoiningYear).ToList();
        }

        static string GetProgramDirectory()
        {
            try
            {
                string assemblyLocation = Assembly.GetExecutingAssembly().Location;
                return Path.GetDirectoryName(assemblyLocation);
            }
            catch
            {
                return null;
            }
        }
    }

    class Employee
    {
        public string Education { get; set; }
        public int JoiningYear { get; set; }
        public string City { get; set; }
        public int PaymentTier { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public bool EverBenched { get; set; }
        public int ExperienceInCurrentDomain { get; set; }
        public bool LeaveOrNot { get; set; }

        public override string ToString()
        {
            return $"Education: {Education}, JoiningYear: {JoiningYear}, City: {City}, PaymentTier: {PaymentTier}, Age: {Age}, Gender: {Gender}, EverBenched: {EverBenched}, ExperienceInCurrentDomain: {ExperienceInCurrentDomain}, LeaveOrNot: {LeaveOrNot}";
        }
    }
}
