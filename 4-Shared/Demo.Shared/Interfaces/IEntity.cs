using System;

namespace Demo.Shared.Interfaces
{
    public interface IEntity
    {
        Guid Id { get;  set; }
        DateTime CreateAt { get; set; }
        DateTime? UpdateAt { get;  set; }

    }
}
