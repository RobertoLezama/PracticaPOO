using System;

namespace PracticaPOO.UI
{
    internal class ConsoleMenuOption
    {
        public string Name { get; set; }

        public Action Selected { get; }

        public ConsoleMenuOption(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }

        //public void SetName(string name);
    }
}
