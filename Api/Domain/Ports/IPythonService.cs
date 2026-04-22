using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Ports
{
    public class IPythonService
    {
        Task<string> GerarConfigApexAsync(string jsonDados, string tipoGrafico);
    }
}