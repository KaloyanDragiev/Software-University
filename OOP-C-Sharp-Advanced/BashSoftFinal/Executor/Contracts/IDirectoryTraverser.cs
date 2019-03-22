﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Contracts
{
    public interface IDirectoryTraverser
    {
        void TraverseDirectory(int depth);
    }
}
