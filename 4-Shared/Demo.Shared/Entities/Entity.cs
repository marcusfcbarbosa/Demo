using Demo.Shared.Interfaces;
using FluentValidator;
using System;

namespace Demo.Shared.Entities
{
    public class Entity : Notifiable, IEntity
    {
        public Entity()
        {
        }
        public Guid Id { get;  set; }
        public DateTime CreateAt { get;  set; }
        public DateTime? UpdateAt { get; set; }
    }
}
