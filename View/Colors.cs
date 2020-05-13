using System;
using System.Drawing;
using CoronavirusCashFlow.Model.Enums;

namespace CoronavirusCashFlow.View
{
    public static class Colors
    {
        public static Color GetColor(ColorType type)
        {
            switch (type)
            {
                case ColorType.DarkGreen: return Color.FromArgb(0, 61, 0);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}