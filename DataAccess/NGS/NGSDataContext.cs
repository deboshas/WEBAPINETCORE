using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DataContext.Extension;
using DataContext;

namespace NGS.DataContext
{
   public partial class NGSDataContext :BaseDataContext<NGSDataContext>
    {
        public NGSDataContext(DbContextOptions<NGSDataContext> options)
            :base(options)
        {


        }

    }
}
