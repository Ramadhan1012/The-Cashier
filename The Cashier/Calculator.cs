using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace The_Cashier
{
    class Calculator
    {
        private List<Item> listItem;
        private double total = 0;

        public Calculator()
        {
            this.listItem = new List<Item>();
        }

        public void addItem(Item item)
        {
            this.listItem.Add(item);
            this.total += item.getSubtotal();
        }

        public double getTotal()
        {
            return total;
        }

        public List<Item> getLisItem()
        {
            return listItem;
        }
    }
}
