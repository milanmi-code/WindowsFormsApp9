﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        databasehendler db;
        public Form1()
        {
            db = new databasehendler();
            db.readdb();
            InitializeComponent();
        }
    }
}
