using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.BasicObjects
{
    class Player
    {
        private Player instance;

        private Player()
        {

        }

        public Player getInstance()
        {
            if (instance == null)
                instance = new Player();
            return instance;
        }

    }
}
