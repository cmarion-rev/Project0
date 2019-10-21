using System;
using System.Collections.Generic;
using System.Text;

using Project_0.GeneralInterfaces;

namespace Project_0
{
    interface IDisplayGeneral : IDisplayMainMenu, 
                                IDisplayUserInput, 
                                IDisplayErrorMessages
    {
    }
}