using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ejercicios_grupo_timex{
    public class EmployeesDBApi{
        private MySqlConnection Connection;

        private const string Server = "127.0.0.1"; //Usando base de datos alojada en localhost para el ejemplo
        private const string Port = "3306";
        private const string Database = "grupo_timex";
        private const string Table = "employees";
        private const string User = "developer_jr";
        private const string Password = "superStrongPassword";

        public EmployeesDBApi(){
            string connectionString = "Server="+Server+";Port="+Port+";Database="+Database+";Uid="+User+";password="+Password+";";

            this.Connection = new MySqlConnection(connectionString);
        }

        public List<Employee> GetAllEmployees() {
            MySqlCommand sqlCmd = Connection.CreateCommand();
            sqlCmd.CommandText = "SELECT * FROM " + Table;

            return GetEmployeesBasedOnQuery(sqlCmd);
        }

        public List<Employee> GetEmployeesWhoseNamesStartWith(char initialLetter){
            MySqlCommand sqlCmd = Connection.CreateCommand();
            sqlCmd.CommandText = "SELECT * FROM " + Table + " WHERE Nombre REGEXP \"^" + initialLetter + "\"";

            return GetEmployeesBasedOnQuery(sqlCmd);
        }

        public void InsertEmployees(List<Employee> employeesList){
            MySqlCommand sqlCmd =  Connection.CreateCommand();
            sqlCmd.CommandText = "INSERT INTO " + Table + "(Nombre, Apellidos, FechaNacimiento) VALUES(@Nombre, @Apellidos, @FechaNacimiento)";

            Connection.Open();
            employeesList.ForEach(employee => {
                sqlCmd.Parameters.Clear();
                sqlCmd.Parameters.AddWithValue("@Nombre", employee.Nombre);
                sqlCmd.Parameters.AddWithValue("@Apellidos", employee.Apellidos);
                sqlCmd.Parameters.AddWithValue("@FechaNacimiento", employee.FechaNacimiento);
                sqlCmd.ExecuteNonQuery();
            });
            Connection.Dispose();
        }

        private List<Employee> GetEmployeesBasedOnQuery(MySqlCommand sqlCmd){
            List<Employee> employeeList = new List<Employee>();

            Connection.Open();
            using (var reader = sqlCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Employee tempEmployee = new Employee();

                    tempEmployee.IdRegistro = Convert.ToInt32(reader["IdRegistro"]);
                    tempEmployee.Nombre = reader["Nombre"].ToString();
                    tempEmployee.Apellidos = reader["Apellidos"].ToString();
                    tempEmployee.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                    tempEmployee.FechaDeRegistroEnSistema = DateTime.Parse(reader["FechaDeRegistroEnSistema"].ToString());

                    employeeList.Add(tempEmployee);
                }
            }
            Connection.Dispose();

            return employeeList;
        }
    }
}
