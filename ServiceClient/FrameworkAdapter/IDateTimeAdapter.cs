using System;

namespace ServiceClient.FrameworkAdapter
{
    public interface IDateTimeAdapter
    {
        DateTime Now { get; }
    }
}