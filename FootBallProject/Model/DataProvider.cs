using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallProject.Model
{
    public class DataProvider
    {

        private static DataProvider _ins;
        public static DataProvider ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new DataProvider();
                }
                return _ins;

            }
            set { _ins = value; }
        }
        public FOOTBALLMANAGERDEMOEntities DB { get; set; }
        private DataProvider()
        {
            DB = new FOOTBALLMANAGERDEMOEntities();

        }

        private static DataProvider s_instance;

        public static DataProvider Instance => s_instance ?? (s_instance = new DataProvider());

        private DataProvider()
        {
            Database = new officialleagueEntities();
        }

        public officialleagueEntities Database { get; set; }

    }
}
