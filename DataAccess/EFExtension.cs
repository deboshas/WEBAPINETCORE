using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataContext.Extension
{
    public static  class EFExtension
    {
        public static SqlCommand  LoadStoredProc(this DbContext context,string procname )
        {
            var connection= new SqlConnection(context.Database.GetDbConnection().ConnectionString);
            var command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = procname;
            return command;
        }
        //attaching the paremetr to the command which is resposible for executing the  storted procedure
        public static SqlCommand WithSqlParam(this SqlCommand command,string paramName, Action<SqlParameter> parameterInvoke)
        {
            var parameter = new SqlParameter();
            parameter.ParameterName = paramName;
            parameterInvoke?.Invoke(parameter);//c# 7.0 new features
            command.Parameters.Add(parameter);
            return command;
        }

        public static async Task<IEnumerable<T>> ExecuteStoredProcAsync<T>(this DbCommand cmd)
        {
            using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
            {

                if(typeof(T)==typeof(int))
                {

                    return await MapToValueTypeAsync<T>(reader).ConfigureAwait(false);
                }
                else
                {

                    return await MaptoRefTypeAsync<T>(reader).ConfigureAwait(false);
                }

            }



        }

        public static async  Task<IEnumerable<T>> MapToValueTypeAsync<T>(DbDataReader reader)
        {
            var list = new List<T>();        
            while(await reader.ReadAsync().ConfigureAwait(false))
            {
                var value = await reader.GetFieldValueAsync<T>(0).ConfigureAwait(false);
                list.Add(value);

            }
            return list;
        }

        public static async Task<IEnumerable<T>> MaptoRefTypeAsync<T>(DbDataReader reader)
        {
            var list = new List<T>();
            var type = typeof(T);
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                var properties = type.GetProperties().ToList();
                var listobj = Activator.CreateInstance<T>();
                properties.ForEach(item =>
                {
                    var value = reader[item.Name].ToString();//get the value from reader
                    type.GetProperty(item.Name).SetValue(listobj, value);//attahc the value  to the listobj and add it ot the list
                });

                list.Add(listobj);
            }
            return list;


        }

        public static async Task<T> ExecuteScalarAsync<T>(this DbCommand cmd)
        {
            using (cmd)
            {
                if(cmd.Connection.State==System.Data.ConnectionState.Closed)
                {
                    await cmd.Connection.OpenAsync().ConfigureAwait(false);
                }

                try

                {
                    Object result = cmd.ExecuteScalarAsync().ConfigureAwait(false);
                    Type t = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
                    return result == DBNull.Value ? default(T) : (T)Convert.ChangeType(result, t);
                }
                finally
                {

                    cmd.Connection.Close();
                }


            }

        }

        public static async Task<T> ExecuteNonQueryAsync<T>(this DbCommand cmd)
        {
            using (cmd)
            {
                if(cmd.Connection.State==System.Data.ConnectionState.Closed)
                {
                    await cmd.Connection.OpenAsync().ConfigureAwait(false);
                }

                try
                {
                  var result=  await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);


                    return (T)Convert.ChangeType(result, typeof(T));

                }
                finally
                {

                    cmd.Connection.Close();
                }



            }
        }



    }
}
