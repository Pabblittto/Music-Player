using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.BasicObjects
{
    class DataStorage
    {
        private DataStorage instance;

        private DataStorage()
        {

        }

        public DataStorage getInstance()
        {
            if (instance == null)
                instance = new DataStorage();
            return instance;
        }

    }
}
