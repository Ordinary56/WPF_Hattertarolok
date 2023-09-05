using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
#pragma warning disable
namespace Balogh_Tamas_WPF_Hattertar.Core
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        { add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

         Action<object> _execute;
        Predicate<object>? _canexecute;

        public RelayCommand(Action<object> Execute, Predicate<object>? canExecute)
        {
            _execute = Execute ?? throw new ArgumentNullException("Command cannot execute nothing.");
            _canexecute = canExecute;
        }
        public RelayCommand(Action<object> Execute) : this(Execute, null) { }
        public bool CanExecute(object? parameter)
        {
            return _canexecute == null  || _canexecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
