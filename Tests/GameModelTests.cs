using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CoronavirusCashFlow.Tests
{
    public class GameModelTests
    {
        [Test]
        public void GetGameModelDefaultPlayer()
        {
            var player = GameModel.Player;
            Assert.AreEqual("Михаил", player.Name);
        }
        
        [Test]
        public void ChangeStockCostAfterMove()
        {
            var player = new Player(
                "Михаил", 
                "Описание", 
                Car.GetCar("Porsche Cayman"), 
                100000, 
                new List<Asset> {Stock.GetStock("Netflix")}, 
                new List<Liability>());
            var costBeforeMove = player.AssetsList[0].Cost;
            GameModel.GetMove();
            var costAfterMove = player.AssetsList[0].Cost;

            Assert.AreEqual(false, Math.Abs(costBeforeMove - costAfterMove) < double.Epsilon);
        }
    }
}