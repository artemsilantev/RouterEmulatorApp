

using System;
using RouterEmulatorApp.API.Models.Commands;
// ReSharper disable IdentifierTypo

namespace RouterEmulatorApp.Models.Commands
{
    public static class CommandExecuter
    {

        public static bool Execute(ICommand command, out string message)
        {
            try
            {
                command.Execute();
                message = null;
                return true;
            }
            catch (Exception exception)
            {
                message = exception.Message;
                return false;
            }
            
        }
        
    }
}