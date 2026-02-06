using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.Course
{
    class LamdaPractice
    {
        List<Item> _items = new List<Item>();
        /*
         * Lamda: 1회용 함수를 만드는데 사용하는 문법
         */

        Item FindItem(Func<Item, bool> selector)
        {
            foreach (Item item in _items)
            {
                if (selector(item))
                    return item;
            }
            return null;

        }

        public void Run()
        {
            _items.Add(new Item() { ItemType = ItemType.Weapon, Rarity = Rarity.Normal });
            _items.Add(new Item() { ItemType = ItemType.Armor, Rarity = Rarity.Uncommon });
            _items.Add(new Item() { ItemType = ItemType.Ring, Rarity = Rarity.Rare });

            //Anonymous Function
            Item item = FindItem(delegate (Item item)
            {
                if (item.ItemType == ItemType.Weapon)
                    return true;
                else
                    return false;
            });

            Item itemLamda = FindItem((Item item) =>
            {
                if (item.ItemType == ItemType.Weapon)
                    return true;
                else
                    return false;

            });

        }

        enum ItemType
        {
            Weapon,
            Armor,
            Ring
        }

        enum Rarity
        {
            Normal,
            Uncommon,
            Rare
        }

        class Item
        {
            public ItemType ItemType;
            public Rarity Rarity;
        }


    }
}
