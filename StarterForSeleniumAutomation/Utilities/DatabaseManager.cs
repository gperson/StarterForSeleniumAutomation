using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterForSeleniumAutomation.Utilities
{
    public class DatabaseManager
    {
        private string connString;
        private Dictionary<string, List<Object>> _data;

        public DatabaseManager(string connectionString)
        {
            this.connString = connectionString;
        }

        /// <summary>
        /// Queries the database that was intialized with the constructer
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Dictionary with the column names as the key and a value pair that is a list of objects which are the columns </returns>
        public Dictionary<string, List<Object>> QueryDatabase(string query)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = this.connString;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;
            cmd.CommandTimeout = 600;

            sqlConnection.Open();
            Dictionary<string, List<Object>> results = null;
            try
            {
                reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    throw new Exception("Query returned no results.\n Query: " + query);
                }
                int count = reader.FieldCount;
                results = new Dictionary<string, List<Object>>();
                while (reader.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        string colName = reader.GetName(i);
                        Object value = reader.GetValue(i);
                        if (results.ContainsKey(colName))
                        {
                            results[colName].Add(value);
                        }
                        else
                        {
                            results.Add(colName, new List<Object>() { value });
                        }
                    }
                }
            }
            finally
            {
                sqlConnection.Close();
            }
            this._data = results;
            return results;
        }

        /// <summary>
        /// Returns a whole column as a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<T> GetValuesList<T>(string key, Dictionary<string, List<Object>> data = null)
        {
            if (data != null)
            {
                this._data = data;
            }
            List<object> dataObjectList = this._data[key];
            List<T> listObject = new List<T>();
            foreach (object o in dataObjectList)
            {
                try
                {
                    listObject.Add((T)o);
                }
                catch (InvalidCastException)
                {
                    listObject.Add(default(T));
                }
            }
            return listObject;
        }

        /// <summary>
        /// Ges a entry from the result object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="index"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Object GetValueFromData<T>(string key, int index = 0, Dictionary<string, List<Object>> data = null)
        {
            if (data != null)
            {
                this._data = data;
            }
            object value = this._data[key][index];

            if (value is T)
            {
                return (T)value;
            }
            else
            {
                try
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                }
                catch (InvalidCastException)
                {
                    if (IsNullable<object>(value))
                    {
                        return null;
                    }
                    return default(T);
                }
            }
        }

        /// <summary>
        /// If an object is nullable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsNullable<T>(T obj)
        {
            if (obj == null) return true;
            Type type = typeof(T);
            if (!type.IsValueType) return true;
            if (Nullable.GetUnderlyingType(type) != null) return true;
            return false;
        }

        public Dictionary<string, List<Object>> Data
        {
            set
            {
                this._data = value;
            }
        }

    }
}
