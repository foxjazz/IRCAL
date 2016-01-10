using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace myIRC
{
    public partial class dbComp : Component
    {
        public dbComp()
        {
            InitializeComponent();
        }

        public dbComp(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
