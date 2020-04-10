using System;
using System.Collections.Generic;

namespace RedPoint.Scrips
{
    public interface IRedPointTreeMap
    {
        Type Nodes { get; }
        Dictionary<Enum, Type> Tree { get; }
    }
}