//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineAuction.Logic.Domains
{
    using System;
    using System.Collections.Generic;
    
    public partial class Section
    {
        public Section()
        {
            this.Lots = new HashSet<Lot>();
        }
    
        public int Id { get; set; }
        public string NameSection { get; set; }
    
        public virtual ICollection<Lot> Lots { get; set; }
    }
}