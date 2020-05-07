using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CoronavirusCashFlow
{
    public class PlayingField
    {
        public const int Cells = 78;
        public static List<PlayingCell> FieldList;
        
        private readonly List<Control> _okButton = new List<Control>
        {
            GameForm.PassButton,
        };

        public PlayingField()
        {
            FieldList = new List<PlayingCell>();

            var advises = new List<Advice>
            {
                new Advice(
                    "Если хотите стать богатым — инвестируйте в себя! Первым вложением любого инвестора должна быть его личность, его навыки, его знания!",
                    _okButton),
                new Advice("В мире финансовых инструментов деньги - это все, из чего состоят срочные депозиты, государственные облигации и другие инструменты денежного рынка.\n \nЕсли вы хотите быстро разбогатеть, то не храните наличные деньги - капитал не сможет вырасти, если ничего с ним не делать.",
                    _okButton),
                new Advice($"Достигните своей мечты: деньги лишь средство, а не цель!\n \nМечта: {GameModel.Player.Dream.Title}",
                    _okButton),
            };
            
            for (var i = 0; i <= Cells; i++) FieldList.Add(advises[new Random().Next(advises.Count)]);
        }
    }

    public class PlayingCell
    {
        public readonly string Title;
        public readonly string Description;
        public readonly List<Control> Buttons;

        protected PlayingCell(string title, string description, List<Control> buttons)
        {
            Title = title;
            Description = description;
            Buttons = buttons;
        }
    }

    public class Advice : PlayingCell
    {
        public Advice(string description, List<Control> buttons, string title = "Совет") : base(title, description, buttons)
        {
        }
    }
}