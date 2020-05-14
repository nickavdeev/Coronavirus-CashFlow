using CoronavirusCashFlow.Model.Assets;
using CoronavirusCashFlow.Model.Enums;
using CoronavirusCashFlow.Model.Liabilities;
using CoronavirusCashFlow.Model.Players;
using NUnit.Framework;

namespace CoronavirusCashFlow.Tests
{
    public class PlayerTests
    {
        [Test]
        public void CreatePlayer()
        {
            var player = new Player(PlayerName.Mike);
            Assert.AreEqual("Михаил", player.Name);
        }

        [Test]
        public void GetPlayerMike()
        {
            var player = new Player(PlayerName.Mike);
            Assert.AreEqual("Porsche Cayman", player.Dream.Title);
            Assert.AreEqual("Работа: Программист", player.AssetsList[0].Title);
            Assert.AreEqual("Своя квартира", player.LiabilitiesList[0].Title);
            Assert.AreEqual("Связь и интернет", player.LiabilitiesList[1].Title);
        }
        
        [Test]
        public void RemoveAssetsAndLiabilities()
        {
            var player = new Player();
            player.AddAsset(Stock.GetStock("Metflix"));
            player.AddLiability(Car.GetCar("Volkswagen Polo"));
            player.RemoveAsset(Stock.GetStock("Metflix"));
            player.RemoveLiability(Car.GetCar("Volkswagen Polo"));

            Assert.AreEqual(0, player.AssetsList.Count);
            Assert.AreEqual(0, player.LiabilitiesList.Count);
        }
        
        [Test]
        public void RemoveNonexistentItem()
        {
            var player = new Player();
            player.RemoveAsset(Stock.GetStock("Metflix"));

            Assert.AreEqual(0, player.AssetsList.Count);
        }
        
        [Test]
        public void AddTaxWithCar()
        {
            var player = new Player(PlayerName.Mike);
            player.AddLiability(Car.GetCar("Volkswagen Polo"));

            Assert.AreEqual(true, player.LiabilitiesList.Contains(Tax.GetTax("Транспортный налог")));
        }
    }
}