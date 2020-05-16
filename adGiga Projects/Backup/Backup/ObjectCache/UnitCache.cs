using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using DataObjects;

namespace ObjectCache
{
    public class UnitCache
    {
        private UnitCache()
        {
            lock (dummy)
            {
                DBFunctions.GetInstance().OpenConnection();
                OleDbDataReader reader = DBFunctions.GetInstance().GetReader("Select ID, UnitName From Units");
                Unit unit;
                while (reader.Read())
                {
                    unit = new Unit();
                    unit.ID = (int)reader[0];
                    unit.Name = (string)reader[1];
                    units.Add(unit);
                }
            }
        }

        private List<Unit> units = new List<Unit>();
        private static UnitCache instance;
        public static UnitCache GetInstance()
        {
            if (instance == null)
            {
                instance = new UnitCache();
            }
            return instance;
        }
        public List<Unit> Units
        {
            get
            {
                return units;
            }
        }
        public Unit GetUnitByName(string unitName)
        {
            Unit foundUnit = units.Find(delegate(Unit p) { return p.Name == unitName; });
            return foundUnit;
        }
        public void InsertUnit(Unit unit)
        {
            if (GetUnitByName(unit.Name) == null)
            {
                InsertUnitToDB(unit);
                //then add it to cache with db ID
                units.Add(GetUnitFromDbByName(unit.Name));
            }
        }
        private void InsertUnitToDB(Unit unit)
        {
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Insert Into Units " +
                "(UnitName, LastUpdatedTime) Values(LCase(?), Now())");
            command.Parameters.AddWithValue("UnitName", unit.Name);
            command.ExecuteNonQuery();
        }
        private Unit GetUnitFromDbByName(string name)
        {
            Unit unit = new Unit();
            unit.Name = name;
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Select ID From Units Where UnitName = LCase(?)");
            command.Parameters.AddWithValue("UnitName", unit.Name);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                unit.ID = (int)reader[0];
            }
            else
            {
                unit = null;
            }
            return unit;
        }

        public Unit GetUnitById(int unitId)
        {
            Unit foundUnit = units.Find(delegate(Unit p) { return p.ID == unitId; });
            return foundUnit;            
        }

        private object dummy = new object();

        public void Clear()
        {
            if (units != null)
            {
                units.Clear();
            }
            instance = null;
        }
    }
}
