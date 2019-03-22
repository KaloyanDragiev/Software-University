﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Contracts
{
    public interface IInterpreter
    {
        void InterpretCommand(String command);
    }
}
