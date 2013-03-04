﻿using System;
using System.Windows.Input;
using UpDownSingnalsServer.ViewModels;

namespace UpDownSingnalsServer.Commands
{
    public class RefreshCommand : ICommand
    {
        private UpDownSignalsServerShellViewModel _signalsServerShellViewModel;
        
        /// <summary>
        /// Argument Constructor
        /// </summary>
        /// <param name="signalsServerShellViewModel"></param>
        public RefreshCommand(UpDownSignalsServerShellViewModel signalsServerShellViewModel)
        {
            this._signalsServerShellViewModel = signalsServerShellViewModel;
        }

        #region ICommand Members
        /// <summary>
        /// Can execute the command. Should button be enabled or disabled.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Action when button is clicked
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            this._signalsServerShellViewModel.RefreshUI();
        }
        #endregion
    }
}