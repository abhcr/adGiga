using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using DataObjects;
using ObjectCache;

namespace Business
{
    public class UnitManager
    {
        public string[] GetNamesOfUnits()
        {
            List<string> nameList = new List<string>();
            foreach (Unit unit in (UnitCache.GetInstance()).Units)
            {
                nameList.Add(unit.Name);
            }
            return nameList.ToArray();
        }

        public Unit SyncUnit(Unit unit)
        {
            if (UnitCache.GetInstance().GetUnitByName(unit.Name) == null)
            {
                UnitCache.GetInstance().InsertUnit(unit);
            }
            return UnitCache.GetInstance().GetUnitByName(unit.Name);
        }

        internal void RefreshCache()
        {
            UnitCache.GetInstance().Clear();
            UnitCache.GetInstance();
        }
    }
}
