using System;

namespace Demo.Shared.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreateAt { get; set; }
        DateTime? UpdateAt { get; set; }

    }
}
