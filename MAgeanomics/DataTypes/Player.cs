using Mageanomics.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mageanomics.DataTypes
{
    public class Player
    {
        public Player(string name, Deck deck)
        {
            this.Name = name;
            this.Library = deck;
            this.NonLandPermanents = new HashSet<Card>();
            this.Lands = new HashSet<Card>();
            this.Hand = new HashSet<Card>();
            this.Graveyard = new HashSet<Card>();
        }

        public string Name
        {
            get;
            private set;
        }

        public Deck Library
        {
            get;
            private set;
        }

        public int LifeTotal
        {
            get;
            set;
        }

        public HashSet<Card> Graveyard
        {
            get;
            private set;
        }

        public HashSet<Card> NonLandPermanents
        {
            get;
            private set;
        }

        public HashSet<Card> Lands
        {
            get;
            private set;
        }

        public HashSet<Card> Hand
        {
            get;
            private set;
        }
    }
}
