using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Communication
{
    // Converts between the paths and the values like in MileStone 1
    class SymbolTable
    {
        private Dictionary<string, double> map { get; }

        // The symbol table can be created only once
        #region Singleton
        private static SymbolTable m_Instance = null;
        public static SymbolTable Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new SymbolTable();
                }
                return m_Instance;
            }
        }
        #endregion

        public void Add(string path, double val)
        {
            map.Add(path, val);
        }

        public double GetVal(string path)
        {
            return map[path];
        }
    }
}
