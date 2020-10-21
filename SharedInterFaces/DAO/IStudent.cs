using System;

namespace Shared.DAO
{
    public interface IStudent
    {
        string[] FirstNames { get; }
        string LastName { get; }
        DateTime BirthDay { get; }
    }
}
