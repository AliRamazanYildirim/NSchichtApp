﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSchicht.Dienst.Ausnahmen
{
    public class ClientSeitigeAusnahme:Exception
    {
        public ClientSeitigeAusnahme(string nachricht) : base(nachricht)
        {

        }
    }
}
