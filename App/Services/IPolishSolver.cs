using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testCase.Services
{
    public interface IPolishSolver
    {
        double? Calculate(string data);
    }
}
