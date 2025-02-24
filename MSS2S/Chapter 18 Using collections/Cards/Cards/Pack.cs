using System;
using System.Collections.Generic;


namespace Cards
{
    class Pack
    {
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;

        // private PlayingCard[,] cardPack;
        private Dictionary<Suit, List<PlayingCard>> cardPack;  //利用Dictionary集合替换二维数组
                                                               //建表示花色（suit）,值是该花色下的牌的list

        private Random randomCardSelector = new Random();

        public Pack()
        {
            //this.cardPack = new PlayingCard[NumSuits, CardsPerSuit];
            this.cardPack = new Dictionary<Suit,List<PlayingCard>>(NumSuits);
            //尽管 Dictionary 集合在添加元素时会自动调整自身大小，但如果该集合的大小不太可能发生变化，
            //您可以在实例化它时指定一个初始大小。这有助于优化内存分配（尽管 Dictionary 集合仍可能在超
            //出此大小时继续增长）。在这种情况下，Dictionary 集合将包含四个列表的集合（每个花色对应一个
            //列表），因此它为四个元素（NumSuits 是一个常量，其值为 4）分配了空间。


            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {
                //在外部的 for 循环中，声明一个名为 cardsInSuit 的 List<PlayingCard> 集合对象，其容
                //量足以容纳每种花色的牌数（使用 CardsPerSuit 常量）
                List<PlayingCard> cardsInSuit = new List<PlayingCard>(CardsPerSuit);


                for (Value value = Value.Two; value <= Value.Ace; value++)
                {
                    //this.cardPack[(int)suit, (int)value] = new PlayingCard(suit, value);
                    cardsInSuit.Add(new PlayingCard(suit, value));  //改用Dictionary

                }
                this.cardPack.Add(suit, cardsInSuit);
            }
        }

        public PlayingCard DealCardFromPack()
        {
            Suit suit = (Suit)randomCardSelector.Next(NumSuits);

            while (this.IsSuitEmpty(suit))
            {
                suit = (Suit)randomCardSelector.Next(NumSuits);
            }

            Value value = (Value)randomCardSelector.Next(CardsPerSuit);
            while (this.IsCardAlreadyDealt(suit, value))
            {
                value = (Value)randomCardSelector.Next(CardsPerSuit);
            }

            //PlayingCard card = this.cardPack[(int)suit, (int)value];
            //this.cardPack[(int)suit, (int)value] = null;
            List<PlayingCard> cardsInSuit = this.cardPack[suit];
            PlayingCard card = cardsInSuit.Find(c => c.CardValue == value);
            cardsInSuit.Remove(card);
            return card;
        }

        private bool IsSuitEmpty(Suit suit)
        {
            bool result = true;
            for (Value value = Value.Two; value <= Value.Ace; value++)
            {
                if (!IsCardAlreadyDealt(suit, value))
                {
                    result = false;
                    break;
                }
            }

            return result;

        }

        private bool IsCardAlreadyDealt(Suit suit, Value value)
        {
            //return (this.cardPack[(int)suit, (int)value] == null);
            List<PlayingCard> cardsInSuit=this.cardPack[suit];
            return (!cardsInSuit.Exists(c=>c.CardSuit==suit && c.CardValue==value));

        }
    }
}