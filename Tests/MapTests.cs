using CoronavirusCashFlow.Model;
using CoronavirusCashFlow.Model.Players;
using NUnit.Framework;

namespace CoronavirusCashFlow.Tests
{
    public class MapTests
    {
        [Test]
        public void CreateMap()
        {
            var currentMap = new Map();
            Assert.AreEqual(360, currentMap.PlayingMap.Count);
        }
        
        [Test]
        public void ChangeCurrentPosition()
        {
            GameModel.GetMove();
            var currentPosition = GameModel.Player.CurrentPosition;
            Assert.AreEqual(true, 0 < currentPosition);
        }
    }
}