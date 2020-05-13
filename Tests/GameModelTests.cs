using System;
using System.Collections.Generic;
using CoronavirusCashFlow.Model;
using CoronavirusCashFlow.Model.Assets;
using CoronavirusCashFlow.Model.Liabilities;
using CoronavirusCashFlow.Model.Players;
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
            var player = new Mike();
            var costBeforeMove = player.AssetsList[0].Cost;
            GameModel.GetMove();
            var costAfterMove = player.AssetsList[0].Cost;

            Assert.AreEqual(false, Math.Abs(costBeforeMove - costAfterMove) < double.Epsilon);
        }
    }
}