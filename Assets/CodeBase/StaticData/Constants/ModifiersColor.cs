using UnityEngine;

namespace CodeBase.Service
{
    public static class ModifiersColor
    {
        public static readonly Color Common = new Color(0.7f, 0.7f, 0.7f, 1.0f); // Gray for Common
        public static readonly Color Uncommon = new Color(0.2f, 0.8f, 0.2f, 1.0f); // Bright Green for Uncommon
        public static readonly Color Rare = new Color(0.1f, 0.3f, 0.8f, 1.0f); // Deep Blue for Rare
        public static readonly Color Epic = new Color(0.6f, 0.2f, 0.8f, 1.0f); // Rich Purple for Epic
        public static readonly Color Legendary = new Color(1.0f, 0.65f, 0.0f, 1.0f); // Vibrant Orange for Legendary
    }
}