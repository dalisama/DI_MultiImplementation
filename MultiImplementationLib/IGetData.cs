using System;
using System.Collections.Generic;
using System.Text;

namespace MultiImplementationLib
{
    public interface IGetData
    {
        Keys Tag { get; }
        string GetData();
    }
}
