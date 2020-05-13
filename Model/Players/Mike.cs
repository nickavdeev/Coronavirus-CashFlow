using System.Collections.Generic;
using CoronavirusCashFlow.Model.Assets;
using CoronavirusCashFlow.Model.Liabilities;

namespace CoronavirusCashFlow.Model.Players
{
    public class Mike : Player
    {
        public Mike()
        {
            Name = "Михаил";
            Description = "Студент со своей однокомнатной квартирой и стабильной работой. Но Михаил уверен, что способен на большее!";
            Dream = Car.GetCar("Porsche Cayman");
            Savings = 100000;
            AssetsList = new List<Asset>
            {
                Work.GetWork("Программист"),
                Stock.GetStock("Metflix"),
                Stock.GetStock("Gilead Sciences"),
            };
            LiabilitiesList = new List<Liability>
            {
                SocialNeed.GetSocialNeed("Своя квартира"),
                SocialNeed.GetSocialNeed("Связь и интернет"),
                Car.GetCar("Volkswagen Polo"),
            };
        } 
    }
}