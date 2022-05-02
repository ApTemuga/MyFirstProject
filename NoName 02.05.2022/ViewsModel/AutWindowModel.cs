using NoName_02._05._2022.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NoName_02._05._2022.ViewsModel
{
    class AutWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler EventCloseWindow;

        private BaseCommands changeToRegWindow;

        public BaseCommands ChangeToRegWindow
        {
            get
            {
                return changeToRegWindow ?? (changeToRegWindow = new BaseCommands(obj =>
                {
                    WindowsBuilder.ShowRegWindow();
                    CloseWindow();
                }));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public void CloseWindow() => EventCloseWindow?.Invoke(this, EventArgs.Empty);
    }
}
