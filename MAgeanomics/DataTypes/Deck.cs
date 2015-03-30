using Mageanomics.Collections;
using Mageanomics.enums;
using System.Collections.Generic;

namespace Mageanomics.DataTypes
{
    public class Deck
    {
        private ZipList<Card> deck;

        public Deck(Dictionary<Card, int> deckList)
        {
            this.deck = new ZipList<Card>();

            // add every card to the list
            foreach (var card in deckList.Keys)
            {
                for (int i = 0; i < deckList[card]; i++)
                {
                    this.deck.AddBack(card.Clone());
                }
            }
        }

        public int Count
        {
            get
            {
                return this.deck.Count;
            }
        }
        
        public Card Draw()
        {
            return this.deck.RemoveFront();
        }

        public void RiffleShuffle(int times)
        {
            for (int i = 0; i < times; i++)
            {
                var cut = this.deck.Split();
                this.deck.Zip(ref cut);
            }
        }

        public void CutAndMerge()
        {
            var cut = this.deck.Split();
            this.deck.Concat(ref cut, Direction.Bottom);
        }

        public void PileShuffle(int numPiles)
        {
            var piles = new Dictionary<int, ZipList<Card>>();

            while (this.deck.Count > 1)
            {
                for (int pileNumber = 0; pileNumber < numPiles; pileNumber++)
                {
                    ZipList<Card> pile = null;
                    if (!piles.TryGetValue(pileNumber, out pile))
                    {
                        pile = new ZipList<Card>();
                        piles.Add(pileNumber, pile);
                    }

                    if (this.deck.Count > 1)
                    {
                        var card = this.deck.RemoveFront();
                        pile.AddFront(card);
                    }
                    else if (this.deck.Count == 0)
                    {
                        break; // break for loop, while will terminate on its own.
                    }
                } 
            }

            for (int pileNumber = 0; pileNumber < numPiles; pileNumber++)
            {
                var pile = piles[pileNumber];

                if (pileNumber % 2 == 0)
                {
                    this.deck.Concat(ref pile, Direction.Top);
                }
                else
                {
                    this.deck.Concat(ref pile, Direction.Bottom);
                }
            }
        }
    }
}
