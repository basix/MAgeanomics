using System;
using System.Collections.Generic;
namespace Mageanomics.DataTypes
{
    // TODO:
    public class DeckList
    {
        private Dictionary<Card, int> deckList;

        public Deck ToDeck()
        {
            return new Deck(deckList);
        }

        public void AddCard(Card card, int count)
        {
            int n = 0;

            if (this.deckList.TryGetValue(card, out n))
            {
                this.deckList[card] += count;
            }
            else
            {
                this.deckList.Add(card, count);
            }
        }

        public void IncrementCardCount(Card card)
        {
            this.AddCard(card, 1);
        }

        public void DecrementCount(Card card)
        {
            this.AddCard(card, -1);
        }

        public void RemoveCard(Card card)
        {
            this.deckList.Remove(card);
        }
    }
}
