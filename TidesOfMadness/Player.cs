﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TidesOfMadness
{
    public class Player
    {
        public CardCollection CardsInHand { get; set; }
        public CardCollection CardsInPlay { get; set; }
        public int CardsPlayedThisRound { get; set; }
        public int MadnessThisRound { get; set; }
        public int MadnessTotal { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }

        public Player(string name)
        {
            CardsInHand = new CardCollection();
            CardsInPlay = new CardCollection();
            MadnessThisRound = 0;
            MadnessTotal = 0;
            Score = 0;
            Name = name;
        }

        public void PlaySelectedCard(Card card)
        {
            //Play the card that is passed in
            //Check if it exists in CardsInHand
            //If so, remove it from CardsInHand, add it to CardsInPlay, and return true
            //Otherwise, return false

            //BVJ TODO: Error handling
            if (card.HasMadness)
            {
                MadnessThisRound++;
            }

            if (card.CardNameEnum == CardNames.Shub_Niggurath && CardsInPlay.CardsInCollection.Count > 0 && CardsPlayedThisRound > 0)
            {
                CardsInPlay.CardsInCollection[CardsInPlay.CardsInCollection.Count - 1].DoubleScore = true;
            }

            CardsInHand.MoveCardToAnotherCollection(card, CardsInPlay);

            CardsPlayedThisRound++;
        }

        public void ReturnCardToHand(Card card)
        {
            CardsInPlay.MoveCardToAnotherCollection(card, CardsInHand);
        }

        public BindingList<Card> GetCardsInHand()
        {
            return this.CardsInHand.CardsInCollection;
        }

        public BindingList<Card> GetCardsInPlay()
        {
            return this.CardsInPlay.CardsInCollection;
        }

        public bool CheckForSpecificCardInPlay(CardNames cardName)
        {
            if (GetCardsInPlay().Any(c => c.CardNameEnum == cardName))
            {
                return true;
            }
            return false;
        }
    }
}
