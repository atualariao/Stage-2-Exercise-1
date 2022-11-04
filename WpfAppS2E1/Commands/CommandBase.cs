using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppS2E1.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        //IReactiveCommand

        //public IObservable<bool> IsExecuting => throw new NotImplementedException();

        //public IObservable<bool> CanExecute => throw new NotImplementedException();

        //public IObservable<Exception> ThrownExceptions => throw new NotImplementedException();

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
