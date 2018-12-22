using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Extension
{
    public static class IEnumerableExtension
    {

        public static IEnumerable<SqlDataRecord> CreateSqlDataRecord(this IEnumerable<int> records)
        {
            var metaData = new SqlMetaData[1];
            metaData[0] = new SqlMetaData("IntegerID", System.Data.SqlDbType.Int);
            foreach(var item in records)
            {
                var sqlRecord = new SqlDataRecord(metaData);
                sqlRecord.SetInt32(0, item);
                yield return sqlRecord;
            }

        }

         public static IEnumerable<SqlDataRecord> CreateSqlDataRecord(this IEnumerable<string> records)
        {
            var metaData = new SqlMetaData[1];
            metaData[0] = new SqlMetaData("Code", System.Data.SqlDbType.VarChar);

            foreach(var item in records)
            {
                var sqlDataRecord = new SqlDataRecord(metaData);
                sqlDataRecord.SetSqlString(0,item);
                yield return sqlDataRecord;

            }



        }

         public static IEnumerable<SqlDataRecord> CreateSqlDataRecord(this IEnumerable<Tuple<int,string,bool>> records)
        {
            var metaData = new SqlMetaData[3];
            metaData[0] = new SqlMetaData("IntegerID", System.Data.SqlDbType.Int);
            metaData[1] = new SqlMetaData("Code", System.Data.SqlDbType.VarChar);
            metaData[2] = new SqlMetaData("IsSelected", System.Data.SqlDbType.Bit);
            foreach(var item in records)
            {
                var sqldataRecord = new SqlDataRecord(metaData);
                sqldataRecord.SetInt32(0, item.Item1);
                sqldataRecord.SetSqlString(1, item.Item2);
                sqldataRecord.SetSqlBoolean(2, item.Item3);
                yield return sqldataRecord;
            }

        }

        public static IEnumerable<SqlDataRecord> CreateSqlDataRecord(this IDictionary<int,string> records)
        {
            var metaData = new SqlMetaData[2];
            metaData[0] = new SqlMetaData("IntegerID", System.Data.SqlDbType.Int);
            metaData[1] = new SqlMetaData("Code", System.Data.SqlDbType.VarChar);       
            foreach (var item in records)
            {
                var sqldataRecord = new SqlDataRecord(metaData);
                sqldataRecord.SetInt32(0, item.Key);
                sqldataRecord.SetSqlString(1, item.Value);           
                yield return sqldataRecord;
            }

        }



    }
    }
