using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallProject.Model
{
    public class DataProvider
    {
        private static DataProvider s_instance;

        public static DataProvider Instance => s_instance ?? (s_instance = new DataProvider());

        private DataProvider()
        {
            Database = new officialleagueEntities();
        }

        public officialleagueEntities Database { get; set; }
    }
}
