using System;
using System.Collections.Generic;

namespace ejercicios_grupo_timex
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeesDBApi employeesDBApi = new EmployeesDBApi();

            //2. Almecenando informacion en la tabla
            List<Employee> employeeList = new List<Employee>();
                employeeList.Add(new Employee("Pedro", "Mola", new DateTime(1979, 10, 11)));
                employeeList.Add(new Employee("Pablo", "Videgaray", new DateTime(1975, 01, 05)));
                employeeList.Add(new Employee("Sonia", "Lopez", new DateTime(1985, 04, 06)));
                employeeList.Add(new Employee("Alex", "Perez", new DateTime(1980, 07, 08)));
            employeesDBApi.InsertEmployees(employeeList);

            //3. Obteniendo entradas con nombres que inicien con 'P'
            List<Employee> employeesWithInitialP = employeesDBApi.GetEmployeesWhoseNamesStartWith('P');
            employeesWithInitialP.ForEach(employee => Console.WriteLine(employee.ToString()));
        }
    }
}
