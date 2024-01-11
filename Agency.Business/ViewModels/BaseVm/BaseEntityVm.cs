using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.ViewModels.BaseVm
{
    public class BaseEntityVm
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
