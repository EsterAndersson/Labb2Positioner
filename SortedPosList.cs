using System;
using System.Collections.Generic;

namespace Labb2
{
    public class SortedPosList
    {
        List<Position> positionList { get; set; }


        //Constructor
        public SortedPosList() => positionList = new List<Position>();



        public int Count()
        {
            return positionList.Count;
        }

        public void Add(Position pos)
        {

            for (int i = 0; i < positionList.Count; i++)
            {
                if (positionList[i] > pos)
                {
                    positionList.Insert(i, pos);
                    return;
                }
            }
            positionList.Add(pos);
        }
        public bool Remove(Position pos)
        {

            bool remove = false;
            for (int i = 0; i < positionList.Count; i++)
            {
                if (positionList[i].Equals(pos))
                {
                    positionList.RemoveAt(i);
                    return remove = true;
                }
            }
            return remove;
        }


        public SortedPosList Clone()
        {
            var clone = new SortedPosList();

            foreach (Position position in positionList)
            {
                clone.Add(position.Clone());
            }
            return clone;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {

            SortedPosList sortedPosList = new SortedPosList();

            foreach (Position pos in positionList)
            {
               double x = pos.X - centerPos.X;
                double y = pos.Y - centerPos.Y;

                double powX = x * x;
                double powY = y * y;

                double posRadius = powX + powY;
                double centerRadius = radius * radius;

                if (posRadius < centerRadius)
                {
                    sortedPosList.Add(pos.Clone());
                }

            }

            return sortedPosList;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            var addedList = sp1.Clone();
            foreach (Position position in sp2.positionList)
            {
                addedList.Add(position);
            }
            return addedList;
        }

        public override string ToString()
        {
            return string.Join(", ", positionList);
        }

    }
}
