using System;
using System.Collections.Generic;
using dg.kata.toyrobot.Models;

namespace dg.kata.toyrobot.tests.EqualityComparers;

public class InstructionEqualityComparer : IEqualityComparer<Instruction>
{
    public bool Equals(Instruction x, Instruction y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.InstructionName == y.InstructionName && x.X == y.X && x.Y == y.Y && x.Direction == y.Direction;
    }

    public int GetHashCode(Instruction obj)
    {
        return HashCode.Combine((int)obj.InstructionName, obj.X, obj.Y, (int)obj.Direction);
    }
}