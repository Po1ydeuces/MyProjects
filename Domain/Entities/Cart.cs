using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Furniture furniture, int quantity)
        {
            CartLine line = lineCollection
                .Where(f => f.Furniture.Id == furniture.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Furniture = furniture,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Furniture furniture)
        {
            lineCollection.RemoveAll(l => l.Furniture.Id == furniture.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Furniture.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Furniture Furniture{ get; set; }
        public int Quantity { get; set; }
    }

}
