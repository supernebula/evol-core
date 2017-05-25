using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.Common.Schedule
{
    public interface IJobWorker
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        Task Handle();
    }
}
