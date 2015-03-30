
using Mageanomics.Enums;

namespace Mageanomics.DataTypes
{
    public class Card
    {
        public int ConvertedManaCost
        {
            get;
            set;
        }

        public int ColoredSymbols
        {
            get;
            set;
        }

        public Color Color
        {
            get;
            set;
        }

        public CardType Type
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Power
        {
            get;
            set;
        }

        public int Toughness
        {
            get;
            set;
        }

        public Card Clone()
        {
            return this.MemberwiseClone() as Card;
        }
    }
}
