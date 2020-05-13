using System.Collections.Generic;
using CoronavirusCashFlow.Model;
using CoronavirusCashFlow.Model.Assets;
using CoronavirusCashFlow.Model.Liabilities;
using NUnit.Framework;

namespace CoronavirusCashFlow.Tests
{
    public class AssetsAndLiabilityTests
    {
        [Test]
        public void GetAssets()
        {
            var work = Work.GetWork("Программист");
            Assert.AreEqual("Работа: Программист", work.Title);
            
            var stock = Stock.GetStock("Netflix");
            Assert.AreEqual("Акции Netflix", stock.Title);
        }
        
        [Test]
        public void GetWrongAsset()
        {
            Assert.Throws<KeyNotFoundException>(() => Work.GetWork("Несуществующий вид работы"));
        }
        
        [Test]
        public void GetLiability()
        {
            var socialNeed = SocialNeed.GetSocialNeed("Своя квартира");
            Assert.AreEqual("Своя квартира", socialNeed.Title);
            
            var car = Car.GetCar("Volkswagen Polo");
            Assert.AreEqual("Автомобиль: Volkswagen Polo", car.Title);
        }
        
        [Test]
        public void GetWrongLiability()
        {
            Assert.Throws<KeyNotFoundException>(() => Car.GetCar("ВАЗ 2109"));
        }
    }
}