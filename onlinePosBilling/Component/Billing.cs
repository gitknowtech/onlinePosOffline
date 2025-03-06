using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onlinePosBilling.Component
{
    public partial class Billing : Form
    {
        // New constructor that accepts username and store parameters
        public Billing(string username, string store)
        {
            InitializeComponent();
            user.Text = username;  // Set the user label
            this.store.Text = store;  // Set the store label
        }

        // Default constructor if needed
        public Billing()
        {
            InitializeComponent();
        }
    }
}
