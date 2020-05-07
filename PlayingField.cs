using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CoronavirusCashFlow
{
    public class PlayingField
    {
        public const int Cells = 78;
        public readonly List<PlayingCell> FieldList = new List<PlayingCell>();

        private readonly List<Advice> _advises = new List<Advice>
        {
            new Advice(
                "Если хотите стать богатым — инвестируйте в себя! Первым вложением любого инвестора должна быть его личность, его навыки, его знания!",
                new List<Button>{GameForm.PassButton}),
            new Advice(
                "В мире финансовых инструментов деньги - это все, из чего состоят срочные депозиты, государственные облигации и другие инструменты денежного рынка.\n \nЕсли вы хотите быстро разбогатеть, то не храните наличные деньги - капитал не сможет вырасти, если ничего с ним не делать.",
                new List<Button>{GameForm.PassButton}),
            new Advice(
                $"Достигните своей мечты: деньги лишь средство, а не цель!\n \nМечта: {GameModel.Player.Dream.Title}",
                new List<Button>{GameForm.PassButton}),
        };

        public PlayingField()
        {
            for (var i = 0; i <= Cells; i++) 
                FieldList.Add(_advises[new Random().Next(_advises.Count)]);
        }
    }

    public class PlayingCell
    {
        public readonly string Title;
        public readonly string Description;
        public readonly List<Button> Buttons;

        protected PlayingCell(string title, string description, List<Button> buttons)
        {
            Title = title;
            Description = description;
            Buttons = buttons;
        }
    }

    public class Advice : PlayingCell
    {
        public Advice(string description, List<Button> buttons, string title = "Совет") : base(title, description, buttons) { }
    }
}