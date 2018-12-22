using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext.Extension;

namespace DataContext
{
    public class BaseDataContext<U> : DbContext where U : DbContext
    {
        public BaseDataContext (DbContextOptions<U> options)
            :base(options)
            {

            }

        public async Task<IEnumerable<T>> GetDbDataAsync<T>() where T:class
        {
            var procName = GetProcedureName<T>();
            return await this.LoadStoredProc(procName)
                              .ExecuteStoredProcAsync<T>();


        }

        public virtual string GetProcedureName<T>() where T:class
        {
            var type = typeof(T);
            return $"dbo." + type.Name.Replace("_Result", string.Empty);

        }


    }
}
