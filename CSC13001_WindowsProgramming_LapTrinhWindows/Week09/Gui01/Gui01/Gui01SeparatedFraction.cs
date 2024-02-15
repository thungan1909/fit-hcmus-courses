using Contract;
using Gui01;
using System.Windows.Controls;

namespace Gui01SeparatedFraction
{
    public class Gui01SeparatedFraction : IUI
    {
        private IBus _bus;

        public string Name => "Gui01";

        public string Description => "GUI 01 - Seperated Fraction";

        public UserControl MainScreen => new UserControl1(_bus);

        public void DependsOn(IBus ibus)
        {
            _bus = ibus;
        }
    }
}
