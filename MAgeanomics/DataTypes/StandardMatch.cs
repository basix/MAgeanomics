using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mageanomics.DataTypes
{
    public class StandardMatch
    {
        public StandardMatch(Player player1, Player player2)
        {
            this.Player1 = player1;
            this.Player2 = player2;

            // set life totals and 
            this.InitializePlayer(player1);
            this.InitializePlayer(player2);
        }

        private void InitializePlayer(Player player)
        {
            player.LifeTotal = 20;

            player.Library.PileShuffle(7);
            var riffleTimes = new Random((int)DateTime.Now.Ticks).Next(3, 13);
            player.Library.RiffleShuffle(riffleTimes);
            player.Library.CutAndMerge();
        }

        public Player Player1
        {
            get;
            private set;
        }

        public Player Player2
        {
            get;
            private set;
        }
    }
}
