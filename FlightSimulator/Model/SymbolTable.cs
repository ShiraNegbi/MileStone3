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
        
        //The propertyChanged event (an Action is a void function that gets a string as its input)
        public event Action<string> PropertyChanged;

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

        public void Add(string name, double val)
        {
            map.Add(name, val);
            this.PropertyChanged?.Invoke(name);
        }

        public double GetVal(string name)
        {
            return map[name];
        }
    }
}
