using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRole
    {
        public UserRole()
        {
            this.Users = new List<User>();
        }

        public virtual int Id { get; set; }
        public virtual string NameRole { get; set; }

        public virtual IList<User> Users { get; set; }

        public class UserRoleMap : ClassMap<UserRole>
        {
            public UserRoleMap()
            {
                Id(x => x.Id);
                Map(x => x.NameRole);
                HasMany(x => x.Users)
                .Inverse();
            }
        }
    }
}
