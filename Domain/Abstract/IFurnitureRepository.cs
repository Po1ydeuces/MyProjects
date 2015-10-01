using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IFurnitureRepository
    {
        IEnumerable<Furniture> Furnitures { get; }
        IEnumerable<User> Users { get; }
        void CreateFurniture(Furniture furniture);
        void UpdateFurniture(Furniture furniture);
        Furniture DeleteFurniture(Furniture furniture);
    }
}
