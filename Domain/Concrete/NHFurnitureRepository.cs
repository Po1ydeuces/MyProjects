using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Abstract;
using Domain.Entities;
using NHibernate.Linq;

namespace Domain.NHibernate
{
    public class NHFurnitureRepository : IFurnitureRepository
    {
        ISession session = NHibernateHelper.OpenSession();

        public IEnumerable<Furniture> Furnitures
        {
            get { return session.Query<Furniture>().ToList(); }
        }

        public IEnumerable<User> Users
        {
            get { return session.Query<User>().ToList(); }
        }

        public IEnumerable<UserRole> UserRoles
        {
            get { return session.Query<UserRole>().ToList(); }
        }


        public void CreateFurniture(Furniture furniture)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(furniture);
                transaction.Commit();
            }
        }

        public void UpdateFurniture(Furniture furniture)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                Furniture updateFurniture = session.Get<Furniture>(furniture.Id);

                if (updateFurniture != null)
                {
                    updateFurniture.Name = furniture.Name;
                    updateFurniture.Description = furniture.Description;
                    updateFurniture.Price = furniture.Price;
                    updateFurniture.Section = furniture.Section;
                    updateFurniture.ImageData = furniture.ImageData;
                    updateFurniture.ImageMimeType = furniture.ImageMimeType;
                }
                session.SaveOrUpdate(updateFurniture);
                transaction.Commit();

            }
        }

        public Furniture DeleteFurniture(Furniture furniture)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                Furniture deleteFurniture = session.Get<Furniture>(furniture.Id);
                if (deleteFurniture != null)
                {
                    session.Delete(deleteFurniture);
                    transaction.Commit();
                }
                return deleteFurniture;

            }
        }



    }
}