using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroEstimulator.Domain.ViewModels
{
    public class ListSessionViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
